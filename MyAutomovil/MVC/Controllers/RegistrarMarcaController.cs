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
            nombreMarca = "Amet Industries";
            var entidadMarca = _registrarMarca.ConsultarMarca(nombreMarca);
            ActualizarMarcaViewModel ActualizarMarcaVm = new ActualizarMarcaViewModel
            {
                nombreMarca = entidadMarca.nombreMarca,
                pais = entidadMarca.pais
            };
            return View(ActualizarMarcaVm);
        }

        [HttpPost]
        public ActionResult ActualizarMarca(ActualizarMarcaViewModel nuevaMarca)
        {
            if (nuevaMarca.nombreMarca == null)
            {
                ViewData["MensajeMarca"] = "Campos obligatorios";
                return View();
            }
            else if (nuevaMarca.pais == null)
            {
                ViewData["MensajePais"] = "Campos obligatorios";
                return View();
            }
            Dominio.EntidadesDominio.Marca marca = new Dominio.EntidadesDominio.Marca
            {
                nombreMarca = nuevaMarca.nombreMarca,
                pais = nuevaMarca.pais
            };
            if (_registrarMarca.ActualizarMarca(marca.nombreMarca, marca.pais))
            {
                return RedirectToAction("ConsultarMarca");
            }
            else
            {
                ViewData["MensajeError"] = "Error al actualizar la marca";
                return View();
            }
        }

        public ActionResult ConsultarMarca()
        {
            return View();
        }
    }
}