using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FacturacionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public List<FacturacionCLS> ListarFacturaciones()
        {
            FacturacionBL objFacturacionBL = new FacturacionBL();
            return objFacturacionBL.ListarFacturaciones();
        }

        public int GuardarFacturacion(FacturacionCLS objFacturacionCLS)
        {
            FacturacionBL objFacturacionBL = new FacturacionBL();
            return objFacturacionBL.GuardarFacturacion(objFacturacionCLS);
        }

        public int EliminarFacturacion(int id)
        {
            FacturacionBL objFacturacionBL = new FacturacionBL();
            return objFacturacionBL.EliminarFacturacion(id);
        }

        public FacturacionCLS RecuperarFacturacion(int id)
        {
            FacturacionBL objFacturacionBL = new FacturacionBL();
            return objFacturacionBL.RecuperarFacturacion(id);
        }

        public List<FacturacionCLS> FiltrarFacturaciones(FacturacionCLS filtro)
        {
            FacturacionBL objFacturacionBL = new FacturacionBL();
            return objFacturacionBL.FiltrarFacturaciones(filtro);
        }
    }
}
