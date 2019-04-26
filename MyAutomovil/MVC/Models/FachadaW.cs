using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio.LogicaDelNegocio;
using Dominio.EntidadesDominio;

namespace MVC.Models
{
    public class FachadaW
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
            List<Cliente> aux = new List<Cliente> ();

            RegistrarCliente r = new RegistrarCliente();
            aux = r.RecuperarClientes();
      
            return aux;
        }

        public List<Cliente> ConsultarCliente(string filtro)
        {
            RegistrarCliente r = new RegistrarCliente();
            List<Cliente> aux = new List<Cliente>();
            string[] Vector = filtro.Split(',');
            aux = r.ConsultarCliente(Vector[0], Vector[1], Int32.Parse(Vector[2]));
            return aux;
        }

        public Cliente retornarCliente(int cedula)
        {
            RegistrarCliente r = new RegistrarCliente();
            Cliente c = null;
            List<Cliente> aux2 = r.RecuperarClientes();
            for (int i = 0; i < aux2.Count; i++)
            {
                if (cedula == aux2[i].Cedula)
                {
                    c = aux2[i];
                }
            }
            return c;
        }

        public void ActualizarCliente()
        {

        }

    }
}