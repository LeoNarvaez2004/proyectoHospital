using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;
using CapaEntidad;
using CapaDatos;

namespace Login.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Login()
        {
            return View();

        }
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(UsuarioCLS objUser)
        {
            if (objUser.clave != objUser.confClave)
            {
                ViewData["mensaje"] = "Las contraseñas no coinciden";
                return View();
            }
            objUser.clave = Encriptar(objUser.clave);

            UsuarioDAL objUserDAL = new UsuarioDAL();
            bool registrado = objUserDAL.RegistrarUsuario(objUser, out string mensaje);

            ViewData["mensaje"] = mensaje;
            return View();
        }

        private string Encriptar(string cadena)
        {
            StringBuilder builder = new StringBuilder();
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] result = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(cadena));
                foreach (byte b in result)
                    builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
        [HttpPost]
        public IActionResult Login(UsuarioCLS objUser)
        {
            objUser.clave = Encriptar(objUser.clave);
            string mensaje;
            UsuarioDAL objUserDAL = new UsuarioDAL();
            bool exito = objUserDAL.IniciarSesion(objUser, out mensaje);
            if (exito)
            {
                ViewData["mensaje"] = mensaje;
                return RedirectToAction("Citas", "Citas");
            }
            else
            {
                ViewData["mensaje"] = mensaje;
                return View();
            }
        }
    }
}
