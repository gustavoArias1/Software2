using Fachada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.EntidadesDominio;
using MVC.Models;

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

        [HttpPost]
        public ActionResult AdicionarMarca(AdicionarMarcaViewModel AdicionarMarca)
        {
            if (AdicionarMarca.nombreMarca == null)
            {
                ViewData["MensajeMarca"] = "Campo obligatorio";
                return View();
            }

            if (AdicionarMarca.pais == null)
            {
                ViewData["MensajePais"] = "Campo obligatorio";
                return View();
            }

            Dominio.EntidadesDominio.Marca Marca = new Dominio.EntidadesDominio.Marca
            {
                nombreMarca = AdicionarMarca.nombreMarca,
                pais = AdicionarMarca.pais
            };
            if(_registrarMarca.AdicionarMarca(Marca.nombreMarca, Marca.pais))
            {

                ViewData["MensajeExito"] = "Exito en la creacion de marca";
                return View();
            }
            else
            {
                ViewData["MensajeIngreso"] = "Error al adicionar marca";
                return View();
            }
            
            
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

        public PartialViewResult ConsultarMarcaF()
        {
            FachadaW f = new FachadaW();
            return PartialView("_Marcas", f.ConsultarMarca());
        }

        [HttpPost]
        public PartialViewResult ConsultarMarcaF(string marcaId)
        {
            List<Marca> l = new List<Marca>();
            FachadaW f = new FachadaW();
            l.Add(f.ConsultarMarca(marcaId));
            return PartialView("_Marcas",l );
        }
    }
}