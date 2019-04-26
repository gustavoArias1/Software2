using Fachada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AutenticarEnElSistemaController : Controller
    {
        private Dominio.LogicaDelNegocio.AutenticarEnElSistema _autenticarEnElSistema;

        public AutenticarEnElSistemaController()
        {
            _autenticarEnElSistema = new Dominio.LogicaDelNegocio.AutenticarEnElSistema();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IndexViewModel usuarioNuevo)
        {
            if (usuarioNuevo.user == null)
            {
                ViewData["MensajeUsuario"] = "Campo obligatorio";
                return View();
            }
            Dominio.EntidadesDominio.Usuario entidadUsuario = new Dominio.EntidadesDominio.Usuario
            {
                user = usuarioNuevo.user,
                contraseña = usuarioNuevo.contraseña
            };
            Boolean bandera = _autenticarEnElSistema.AutenticarUsuario(entidadUsuario.user, entidadUsuario.contraseña);
            if (bandera == true)
            {
                return RedirectToAction("RegistrarVehiculo/ConsultarVehiculo", new { tipo = entidadUsuario.tipo });
            }
            else
            {
                ViewData["MensajeLogueo"] = "Usuario o contraseña incorrecta";
                return View();
            }
        }

        public ActionResult RecuperarContraseña()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarContraseña(RecuperarContraseñaModel cambioContraseña)
        {
            if(cambioContraseña.user == null)
            {
                ViewData["MensajeUsuario"] = "Campo obligatorio";
                return View();
            }
            if(cambioContraseña.contraseña == cambioContraseña.contraseña2)
            {
                Dominio.EntidadesDominio.Usuario entidadUsuario = new Dominio.EntidadesDominio.Usuario
                {
                    user = cambioContraseña.user,
                    contraseña = cambioContraseña.contraseña
                };
                Boolean bandera = _autenticarEnElSistema.RecuperarContraseña(entidadUsuario.user, entidadUsuario.contraseña);
                if (bandera == true)
                {
                    return RedirectToAction("/AutenticarseEnElSistema/Index", new { tipo = entidadUsuario.tipo });
                }
                else
                {
                    ViewData["MensajeLogueo"] = "Error en el ingreso de datos";
                    return View();
                }
            }
            else
            {
                ViewData["MensajeLogueo"] = "Ambas contraseñas deben ser iguales";
                return View();
            }
        }
    }
}