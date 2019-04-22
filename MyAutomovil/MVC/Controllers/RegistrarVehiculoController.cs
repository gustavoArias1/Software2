using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RegistrarVehiculoController : Controller
    {
        // GET: RegistrarVehiculo
        public ActionResult AdicionarVehiculo()
        {
            return View();
        }

        public ActionResult ActualizarVehiculo()
        {
            return View();
        }

        public ActionResult ConsultarVehiculo()
        {
            return View();
        }
    }
}