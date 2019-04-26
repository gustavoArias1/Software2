using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

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
        
        public PartialViewResult RecuperarEmpleados() {
            MVC.Models.Fachada f = new MVC.Models.Fachada();
            return PartialView("_Empleados",f.RecuperarEmpleados());
        }

        public ActionResult ConsultarEmpleado2() {
            return View();
        }

        public ActionResult ConsultarEmpleado3()
        {
            return View();
        }
    }
}