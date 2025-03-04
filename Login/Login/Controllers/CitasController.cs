using Microsoft.AspNetCore.Mvc;
using CapaEntidad;
using CapaDatos;
using CapaNegocio;

namespace Login.Controllers
{
    public class CitasController : Controller
    {
        public IActionResult Citas()
        {
            return View();
        }
        public List<CitasCLS> ListarCitas()
        {
            CitasBL objCitasDAL = new CitasBL();
            return objCitasDAL.ListarCitas();
        }
    }
}
