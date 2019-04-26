using Fachada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RegistrarModeloController : Controller
    {
        private Dominio.LogicaDelNegocio.RegistrarModelo _registrarModelo;

        public RegistrarModeloController()
        {
            _registrarModelo = new Dominio.LogicaDelNegocio.RegistrarModelo();
        }

        public ActionResult AdicionarModelo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarModelo(AdicionarModeloViewModelo AdicionarModelo)
        {
            if (AdicionarModelo.nombreMarca == null)
            {
                ViewData["MensajeMarca"] = "Campo obligatorio";
                return View();
            }

            if (AdicionarModelo.nombreModelo == null)
            {
                ViewData["MensajeModelo"] = "Campo obligatorio";
                return View();
            }

            if (AdicionarModelo.numeroPuertas == null)
            {
                ViewData["MensajePuertas"] = "Campo obligatorio";
                return View();
            }

            if (AdicionarModelo.cilindraje == null)
            {
                ViewData["MensajeCilindraje"] = "Campo obligatorio";
                return View();
            }

            if (AdicionarModelo.transmision == null)
            {
                ViewData["MensajeTransmision"] = "Campo obligatorio";
                return View();
            }

            Dominio.EntidadesDominio.Modelo Modelo = new Dominio.EntidadesDominio.Modelo
            {
                nombreMarca = AdicionarModelo.nombreMarca,
                nombreModelo = AdicionarModelo.nombreModelo,
                numeroPuertas = AdicionarModelo.numeroPuertas,
                cilindraje=AdicionarModelo.cilindraje,
                transmision=AdicionarModelo.transmision


            };


            if (_registrarModelo.AdicionarModelo(Modelo.nombreModelo,Modelo.nombreMarca,Modelo.numeroPuertas,Modelo.cilindraje,Modelo.transmision))
            {

                ViewData["MensajeExito"] = "Exito en la creacion de modelo";
                return View();
            }
            else
            {
                ViewData["MensajeIngreso"] = "Error al adicionar modelo";
                return View();
            }


        }


        public ActionResult ActualizarModelo(string nombreMarca, string nombreModelo)
        {
            nombreMarca = "Commodo LLC";
            nombreModelo = "cx5";
            var entidadModelo = _registrarModelo.ConsultarModelo(nombreModelo, nombreMarca);
            ActualizarModeloViewModel ActualizarModeloVm = new ActualizarModeloViewModel
            {
                nombreMarca = entidadModelo.nombreMarca,
                nombreModelo = entidadModelo.nombreModelo,
                transmision = entidadModelo.transmision,
                numeroPuertas = entidadModelo.numeroPuertas,
                cilindraje = entidadModelo.cilindraje
            };
            return View(ActualizarModeloVm);
        }

        [HttpPost]
        public ActionResult ActualizarModelo(ActualizarModeloViewModel nuevaModelo)
        {
            if (nuevaModelo.nombreMarca == null)
            {
                ViewData["MensajeMarca"] = "Campos obligatorios";
                return View();
            }
            else if (nuevaModelo.nombreModelo == null)
            {
                ViewData["MensajeModelo"] = "Campos obligatorios";
                return View();
            }
            else if (nuevaModelo.transmision == null)
            {
                ViewData["MensajeModelo"] = "Campos obligatorios";
                return View();
            }
            else if (nuevaModelo.numeroPuertas == null)
            {
                ViewData["MensajeNumero"] = "Campos obligatorios";
                return View();
            }
            else if (nuevaModelo.cilindraje == null)
            {
                ViewData["MensajeCilindraje"] = "Campos obligatorios";
                return View();
            }
            Dominio.EntidadesDominio.Modelo modelo = new Dominio.EntidadesDominio.Modelo
            {
                nombreMarca = nuevaModelo.nombreMarca,
                nombreModelo = nuevaModelo.nombreModelo,
                transmision = nuevaModelo.transmision,
                numeroPuertas = nuevaModelo.numeroPuertas,
                cilindraje = nuevaModelo.cilindraje
            };
            if (_registrarModelo.ActualizarModelo(modelo.nombreModelo, modelo.nombreMarca, modelo.numeroPuertas, modelo.cilindraje, modelo.transmision))
            {
                return RedirectToAction("ConsultarModelo");
            }
            else
            {
                ViewData["MensajeError"] = "Error al actualizar la modelo";
                return View();
            }
        }

        public ActionResult ConsultarModelo()
        {
            return View();
        }
    }
}