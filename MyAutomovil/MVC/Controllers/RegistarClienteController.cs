using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.EntidadesDominio;

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
            FachadaW f = new FachadaW();
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
           FachadaW f = new FachadaW();
            return PartialView("_Clientes", f.ConsultarCliente(consultaCliente));
        }

        
        public PartialViewResult ConsultarClienteF() {
            FachadaW f = new FachadaW();
            return PartialView("_Clientes",f.ConsultarCliente());
        }
    }
}