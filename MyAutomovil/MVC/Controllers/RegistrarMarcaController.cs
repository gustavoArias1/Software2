using Fachada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RegistrarMarcaController : Controller
    {
        private Dominio.LogicaDelNegocio.RegistrarMarca _registrarMarca;

        public RegistrarMarcaController()
        {
            _registrarMarca = new Dominio.LogicaDelNegocio.RegistrarMarca();
        }

        public ActionResult AdicionarMarca()
        {
            return View();
        }

        public ActionResult ActualizarMarca(string nombreMarca)
        {
            var entidadMarca = _registrarMarca.ConsultarMarca(nombreMarca);
            ActualizarMarcaViewModel ActualuizarMarcaVm = new ActualizarMarcaViewModel
            {
                nombreMarca = entidadMarca.nombreMarca,
                pais = entidadMarca.pais
            };
            return View(ActualuizarMarcaVm);
        }

        public ActionResult ConsultarMarca()
        {
            return View();
        }
    }
}