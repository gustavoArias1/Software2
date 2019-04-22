using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RegistrarEmpleadoController : Controller
    {
        // GET: RegistrarEmpleado
        public ActionResult AdicionarEmpleado()
        {
            return View();
        }

        public ActionResult ActualizarEmpleado()
        {
            return View();
        }

        public ActionResult ConsultarEmpleado()
        {
            return View();
        }
    }
}