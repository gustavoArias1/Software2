using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RegistrarMarcaController : Controller
    {
        // GET: RegistrarMarca
        public ActionResult AdicionarMarca()
        {
            return View();
        }

        public ActionResult ActualizarMarca()
        {
            return View();
        }

        public ActionResult ConsultarMarca()
        {
            return View();
        }
    }
}