using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RegistrarConcesionarioController : Controller
    {
        // GET: RegistrarConcesionario
        public ActionResult AdicionarConcesionario()
        {
            return View();
        }
        
        public ActionResult ActualizarConcesionario()
        {
            return View();
        }

        public ActionResult ConsultarConcesionario()
        {
            return View();
        }
    }
}