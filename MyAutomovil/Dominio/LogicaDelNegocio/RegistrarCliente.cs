using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.LogicaDelNegocio
{
    class RegistrarCliente
    {
        public List<Cliente> clientes= null;

        public void AdicionarCliente (string nombre, string apellido, int cedula, DateTime fechaDeNacimiento, 
            string correo, string contraseña)
        {
            clientes = RecuperarClientes();
            Cliente cliente = new Cliente(nombre, apellido, fechaDeNacimiento, cedula, correo, contraseña);
            if (clientes.Contains(cliente))
            {
                //lanza execepcion indica que el cliente ya existe
            }
            else
            {
                /*
                Creamos el cliente en la base de datos 
                lanzamos excepcion indica que el cliente ya fue creado
             */
            }
        }

        public void ActualizarCliente(string nombre, string apellido, int cedula, DateTime fechaDeNacimiento,
            string correo, string contraseña)
        {
            /*
             actualizamos en la DB bajo la clausula update
             */
        }

        public List<Cliente> ConsultarCliente(string nombre, string apellido, int cedula)
        {
            List<Cliente> clientesAux = new List<Cliente>();
            clientes = RecuperarClientes();
            try
            {
                for (int i = 0; i < clientes.Count; i++)
                {
                    if (clientes[i].Nombre.Equals(nombre) || clientes[i].Apellido.Equals(apellido) ||
                            clientes[i].Cedula == cedula)
                    {
                        clientesAux.Add(clientes[i]);
                    }
                }
            }
            catch (Exception ex) {
                //Excepcion
            }
            if (clientesAux.Count == 0) {
                //lanzarExcepcion de no se encontraron coincidencias
                return null;
            }
            return clientesAux;
        }

        public void EliminarCliente(string codigo)
        {
            /*
             eliminamos en la base de datos bajo la clausula delete
             */
        }

        /*
         este método recupera de la db los clientes en sumo
         */
        public List<Cliente> RecuperarClientes() {
            List<Cliente> clientesAux = new List<Cliente>();
            /*
             Extraccion db de clientes
             */
            return clientesAux;
        }
    }
}
