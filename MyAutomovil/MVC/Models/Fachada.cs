using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio.LogicaDelNegocio;
using Dominio.EntidadesDominio;

namespace MVC.Models
{
    public class Fachada
    {
        public List<string> RecuperarConcesionarios()
        {
            List<string> aux = new List<string>();
            aux.Add("Los Rosales");
            aux.Add("Casautos");
            aux.Add("los profesionales");
            return aux;
        }

        public List<Vendedor> RecuperarEmpleados()
        {
            List<Vendedor> aux = new List<Vendedor>();
            aux.Add(new Vendedor("Juan", "Cañoi", 1222, "cualquiera", DateTime.Now, "casa"));
            return aux;
        }

        public List<Cliente> ConsultarCliente()
        {
            List<Dominio.EntidadesDominio.Cliente> aux = new List<Dominio.EntidadesDominio.Cliente> ();

            RegistrarCliente r = new RegistrarCliente();
            aux = r.ConsultarCliente();
            //aux.Add(new Cliente("Juan", "apeliiod", .Now, 6877, "acvyah", "cgvjhb"));
            //aux.Add(new Cliente("Juan", "apeliiod", DateTime.Now, 6877, "acvyah", "cgvjhb"));
            //aux.Add(new Cliente("Juan", "apeliiod", DateTime.Now, 6877, "acvyah", "cgvjhb"));
            //aux.Add(new Cliente("Juan", "apeliiod", DateTime.Now, 6877, "acvyah", "cgvjhb"));
            //aux.Add(new Cliente("Juan", "apeliiod", DateTime.Now, 6877, "acvyah", "cgvjhb"));
            List<MVC.Models.Cliente> aux2 = new List<MVC.Models.Cliente>();
            for (int i = 0; i < aux.Count; i++) {
                aux2[i] = ParseClient(aux[i]);
            }
            return aux2;
        }

        public MVC.Models.Cliente ParseClient(Dominio.EntidadesDominio.Cliente c) {
            return new MVC.Models.Cliente(c.Codigo,c.Nombre,c.Apellido,c.FechaDeNacimiento,c.Cedula,c.Correo,c.Contraseña);
        }

        public List<Cliente> ConsultarCliente(string cedula)
        {
            List<Cliente> aux = new List<Cliente>();
            string[] valores = cedula.Split(',');
            aux.Add(new Cliente("Juan", "apeliiod", DateTime.Now, 6877, "acvyah", "cgvjhb"));
            if (Int32.Parse(valores[0]) == aux[0].Cedula)
            {
                aux.Add(new Cliente("Juan", "apeliiod", DateTime.Now, 6879, "acvyah", "cgvjhb"));
            }
            return aux;
        }

        public Cliente retornarCliente(int cedula)
        {
            Cliente c = new Cliente("Juan", "apeliiod", DateTime.Now, 6877, "acvyah", "cgvjhb");
            return c;
        }

        public void ActualizarCliente()
        {

        }

    }
}