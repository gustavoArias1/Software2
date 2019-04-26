using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.EntidadesDominio;
using Fachada;

namespace MVC.Controllers
{
    public class RegistarClienteController : Controller
    {
        private Dominio.LogicaDelNegocio.RegistrarCliente _registrarCliente;

        public RegistarClienteController()
        {
            _registrarCliente = new Dominio.LogicaDelNegocio.RegistrarCliente();
        }

        public ActionResult AdicionarCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionarCliente(AdicionarClienteViewModel nuevoCliente)
        {
            if (nuevoCliente.cedula == null)
            {
                ViewData["MensajeCedula"] = "Campo obligatorio";
                return View();
            }
            else if (nuevoCliente.nombre == null)
            {
                ViewData["MensajeNombre"] = "Campo obligatorio";
                return View();
            }
            else if (nuevoCliente.apellido == null)
            {
                ViewData["MensajeApellido"] = "Campo obligatorio";
                return View();
            }
            else if (nuevoCliente.fechaDeNacimiento == null)
            {
                ViewData["MensajeFecha"] = "Campo obligatorio";
                return View();
            }
            else if (nuevoCliente.correo == null)
            {
                ViewData["MensajeCorreo"] = "Campo obligatorio";
                return View();
            }
            else if (nuevoCliente.contraseña == null)
            {
                ViewData["MensajeContraseña"] = "Campo obligatorio";
                return View();
            }
            else if (nuevoCliente.contraseña2 == null)
            {
                ViewData["MensajeContraseña2"] = "Campo obligatorio";
                return View();
            }
            else if (nuevoCliente.contraseña != nuevoCliente.contraseña2)
            {
                ViewData["MensajeError"] = "Las contraseñas no coiciden";
                return View();
            }
            Dominio.EntidadesDominio.Cliente cliente = new Dominio.EntidadesDominio.Cliente
            {
                cedula = nuevoCliente.cedula,
                nombre = nuevoCliente.nombre,
                apellido = nuevoCliente.apellido,
                fechaDeNacimiento = nuevoCliente.fechaDeNacimiento,
                correo = nuevoCliente.correo,
                contraseña = nuevoCliente.contraseña
            };
            if (_registrarCliente.AdicionarCliente(cliente.nombre, cliente.apellido, cliente.cedula, cliente.fechaDeNacimiento, cliente.correo, cliente.contraseña))
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