using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RegistarClienteController : Controller
    {
        // GET: RegistarCliente
        public ActionResult AdicionarCliente()
        {
            return View();
        }

        public ActionResult ActualizarCliente(int id)
        {
            MVC.Models.Fachada f = new MVC.Models.Fachada();
            return View(f.retornarCliente(id));
        }

        public ActionResult ConsultarCliente()
        {
            return View();
        }

        public void EliminarCliente(int id) {

        }
        [HttpPost]
        public PartialViewResult ConsultarClienteF(string consultaCliente) {
            MVC.Models.Fachada f = new MVC.Models.Fachada();
            return PartialView("_Clientes", f.ConsultarCliente(consultaCliente));
        }

        
        public PartialViewResult ConsultarClienteF() {
            MVC.Models.Fachada f = new MVC.Models.Fachada();
            return PartialView("_Clientes",f.ConsultarCliente());
        }
    }
}