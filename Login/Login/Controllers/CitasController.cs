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
            CitasBL objCitasBL = new CitasBL();
            return objCitasBL.ListarCitas();
        }
        public int GuardarCita(CitasCLS objCitasCLS)
        {
            CitasBL objCitasBL = new CitasBL();
            return objCitasBL.GuardarCita(objCitasCLS);
        }

        public int EliminarCita(int idCita)
        {
            CitasBL objCitasBL = new CitasBL();
            return objCitasBL.EliminarCita(idCita);
        }

        public CitasCLS RecuperarCitas(int idCita)
        {
            CitasBL objCitasBL = new CitasBL();
            return objCitasBL.RecuperarCitas(idCita);
        }

        public List<CitasCLS> FiltrarCitas(CitasCLS objCitasCLS)
        {
            CitasBL objCitasBL = new CitasBL();
            return objCitasBL.FiltrarCitas(objCitasCLS);
        }
    }
}
