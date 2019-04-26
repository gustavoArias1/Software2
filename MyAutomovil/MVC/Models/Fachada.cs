using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;
//using Dominio.EntidadesDominio;

namespace MVC.Models
{
    
    public class Fachada
    {
        public List<string> RecuperarConcesionarios() {
            List<string> aux = new List<string>();
            aux.Add("Los Rosales");
            aux.Add("Casautos");
            aux.Add("los profesionales");
            return aux;
        }

        public List<Vendedor> RecuperarEmpleados()
        {
            List<Vendedor> aux = new List<Vendedor>();
            aux.Add(new Vendedor("Juan","Cañoi",1222,"cualquiera",DateTime.Now,"casa"));
            return aux;
        }

        public List<Cliente>ConsultarCliente() {
            List<Cliente> aux = new List<Cliente>();
            aux.Add(new Cliente("Juan", "apeliiod", DateTime.Now, 6877, "acvyah", "cgvjhb"));
            aux.Add(new Cliente("Juan", "apeliiod", DateTime.Now, 6877, "acvyah", "cgvjhb"));
            aux.Add(new Cliente("Juan", "apeliiod", DateTime.Now, 6877, "acvyah", "cgvjhb"));
            aux.Add(new Cliente("Juan", "apeliiod", DateTime.Now, 6877, "acvyah", "cgvjhb"));
            aux.Add(new Cliente("Juan", "apeliiod", DateTime.Now, 6877, "acvyah", "cgvjhb"));
            return aux;
        }
        public List<Cliente> ConsultarCliente(string cedula)
        {
            List<Cliente> aux = new List<Cliente>();
            string[] valores  = cedula.Split(',');
            aux.Add(new Cliente("Juan", "apeliiod", DateTime.Now, 6877, "acvyah", "cgvjhb"));
            if (Int32.Parse(valores[0]) == aux[0].Cedula) { 
            aux.Add(new Cliente("Juan", "apeliiod", DateTime.Now, 6879, "acvyah", "cgvjhb"));
                 }
            return aux;
        }

        public Cliente retornarCliente(int cedula) {
            Cliente c = new Cliente("Juan", "apeliiod", DateTime.Now, 6877, "acvyah", "cgvjhb");
            return c;
        }

        public void ActualizarCliente() {

        }


    }
}

