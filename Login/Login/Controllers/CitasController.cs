using Microsoft.AspNetCore.Mvc;
using CapaEntidad;
using CapaDatos;

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
            CitasDAL objCitasDAL = new CitasDAL();
            return objCitasDAL.ListarCitas();
        }
    }
}
