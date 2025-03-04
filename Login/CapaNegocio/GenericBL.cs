using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class GenericBL
    {
        public List<int> obtenerClaves(string tabla)
        {
            GenericDAL objGenericDAL = new GenericDAL();
            return objGenericDAL.ObtenerClaves(tabla);
        }
    }
}
