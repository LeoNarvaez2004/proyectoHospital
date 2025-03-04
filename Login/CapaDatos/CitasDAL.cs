using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CitasDAL : CadenaDAL
    {
        public List<CitasCLS> ListarCitas()
        {
            List<CitasCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarCitas", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();
                        lista = new List<CitasCLS>();
                        while (dr.Read())
                        {
                            CitasCLS citas = new CitasCLS();
                            citas.idCita = dr.GetInt32(0);
                            citas.idPaciente = dr.GetInt32(1);
                            citas.idMedico = dr.GetInt32(2);
                            citas.fecha = dr.GetDateTime(3);
                            citas.estado = dr.GetString(4);
                            lista.Add(citas);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Error al listar citas: " + e.Message);
                }
                return lista;
            }
        }

    }
}
