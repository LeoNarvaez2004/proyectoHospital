﻿using CapaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    public class GenericController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<int> obtenerClaves(string tabla)
        {
            GenericBL objGenericBL = new GenericBL();
            return objGenericBL.obtenerClaves(tabla);
        }
    }
}
