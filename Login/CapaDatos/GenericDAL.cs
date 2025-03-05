using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class GenericDAL : CadenaDAL
    {
        public List<int> ObtenerClaves(string tabla)
        {
            List<int> lista = null;
            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Id FROM " + tabla + " ORDER BY Id ASC", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        SqlDataReader dr = cmd.ExecuteReader();
                        lista = new List<int>();
                        while (dr.Read())
                        {
                            lista.Add(dr.GetInt32(0));
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Error al obtener claves: " + e.Message);
                }
                return lista;
            }
        }
    }
}
