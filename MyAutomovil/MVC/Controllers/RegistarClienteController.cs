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

        public ActionResult ActualizarCliente()
        {
            return View();
        }
    }
}