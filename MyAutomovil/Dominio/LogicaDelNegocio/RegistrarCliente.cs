using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.LogicaDelNegocio
{
    class RegistrarCliente
    {
        public void AdicionarCliente (string nombre, string apellido, int cedula, DateTime fechaDeNacimiento, 
            string correo, string contraseña)
        {

        }

        public void ActualizarCliente(string nombre, string apellido, int cedula, DateTime fechaDeNacimiento,
            string correo, string contraseña)
        {

        }

        public LinkedList<Cliente> ConsultarCliente(string nombre, string apellido, int cedula)
        {
            LinkedList<Cliente> lista = new LinkedList<Cliente>();
            return lista;
        }

        public void EliminarCliente(string codigo)
        {

        }
    }
}
