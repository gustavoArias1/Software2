using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using Fachada;

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

        public PartialViewResult ConsultarVehiculoF()
        {
            FachadaW f = new FachadaW();
            return PartialView("_Vehiculos",f.ConsultarVehiculo());
        }
    }
}