using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    public class TratamientosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public List<TratamientosCLS> ListarTratamientos()
        {
            TratamientosBL objTratamientosBL = new TratamientosBL();
            return objTratamientosBL.ListarTratamientos();
        }

        public int GuardarTratamiento(TratamientosCLS objTratamientoCLS)
        {
            TratamientosBL objTratamientosBL = new TratamientosBL();
            return objTratamientosBL.GuardarTratamiento(objTratamientoCLS);
        }

        public int EliminarTratamiento(int id)
        {
            TratamientosBL objTratamientosBL = new TratamientosBL();
            return objTratamientosBL.EliminarTratamiento(id);
        }

        public TratamientosCLS RecuperarTratamiento(int id)
        {
            TratamientosBL objTratamientosBL = new TratamientosBL();
            return objTratamientosBL.RecuperarTratamiento(id);
        }

        public List<TratamientosCLS> FiltrarTratamientos(TratamientosCLS filtro)
        {
            TratamientosBL objTratamientosBL = new TratamientosBL();
            return objTratamientosBL.FiltrarTratamientos(filtro);
        }
    }
}
