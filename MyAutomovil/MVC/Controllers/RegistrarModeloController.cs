using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RegistrarModeloController : Controller
    {
        // GET: RegistrarModelo
        public ActionResult AdicionarModelo()
        {
            return View();
        }

        public ActionResult ActualizarModelo()
        {
            return View();
        }
    }
}