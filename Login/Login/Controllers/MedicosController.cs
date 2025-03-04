using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    public class MedicosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public List<MedicosCLS> ListarMedicos()
        {
            MedicosBL objMedicosBL = new MedicosBL();
            return objMedicosBL.ListarMedicos();
        }

        public int GuardarMedico(MedicosCLS objMedicoCLS)
        {
            MedicosBL objMedicosBL = new MedicosBL();
            return objMedicosBL.GuardarMedico(objMedicoCLS);
        }

        public int EliminarMedico(int id)
        {
            MedicosBL objMedicosBL = new MedicosBL();
            return objMedicosBL.EliminarMedico(id);
        }

        public MedicosCLS RecuperarMedico(int id)
        {
            MedicosBL objMedicosBL = new MedicosBL();
            return objMedicosBL.RecuperarMedico(id);
        }

        public List<MedicosCLS> FiltrarMedicos(MedicosCLS filtro)
        {
            MedicosBL objMedicosBL = new MedicosBL();
            return objMedicosBL.FiltrarMedicos(filtro);
        }
    }
}
