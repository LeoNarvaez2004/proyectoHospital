using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class UsuarioDAL : CadenaDAL
    {
        public bool RegistrarUsuario(UsuarioCLS usuario, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@correo", usuario.correo);
                        cmd.Parameters.AddWithValue("@clave", usuario.clave);
                        cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                        
                        cmd.ExecuteNonQuery();

                        respuesta = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                        mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                    }
                }
                catch (Exception e)
                {
                    mensaje = e.Message;
                }
            }

            return respuesta;
        }
        public bool IniciarSesion(UsuarioCLS usuario, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@correo", usuario.correo);
                        cmd.Parameters.AddWithValue("@clave", usuario.clave);

                        var res = cmd.ExecuteScalar();
                        if (res != null && res.ToString()!="0")
                        {
                            respuesta = true;
                            mensaje = "Inicio de sesión exitoso";
                        }
                        else
                        {
                            respuesta = false;
                            mensaje = "Usuario o contraseña incorrecta";
                        }

                    }
                }
                catch (Exception e)
                {
                    respuesta = false;
                    mensaje = e.Message;
                }
            }

            return respuesta;
        }
    }
}
