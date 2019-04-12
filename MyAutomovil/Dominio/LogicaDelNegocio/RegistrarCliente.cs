using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Text;
using Persistencia;

namespace Dominio.LogicaDelNegocio
{
    class RegistrarCliente : DBFake
    {
        public List<Cliente> clientes;

        /*
         William Andres Vasquez Sanabria 
         Versión 1.0
         context: RegistrarCliente: AdcionarCliente(nombre:string,apellido:string,cedula:int,fechadenacimiento:date,correo:string,
         contraseña:string):void
         pre: RecuperarClientes.Count > 0, clientes.Contains(cliente) != true
         pro: Cliente es agregado en DB, RecuperarClientes.Count  = RecuperarClientes.Count + 1
             */
        public void AdicionarCliente (string nombre, string apellido, int cedula, DateTime fechaDeNacimiento, 
            string correo, string contraseña)
        {
            clientes = RecuperarClientes();
            Cliente cliente = new Cliente(nombre, apellido, fechaDeNacimiento, cedula, correo, contraseña);
            if (clientes.Count > 0)
            {
                if (clientes.Contains(cliente))
                {
                    //lanza execepcion indica que el cliente ya existe
                    System.Console.WriteLine("El cliente ya existe");
                }
                else
                {
                    AdicionarClienteRepositorio(nombre, apellido,   fechaDeNacimiento, cedula, correo, contraseña);
                    System.Console.WriteLine("El cliente ha sido creado");
                }
            }
            else {
                
                AdicionarClienteRepositorio(nombre, apellido, fechaDeNacimiento, cedula, correo, contraseña);
                System.Console.WriteLine("El cliente ha sido creado");
            }
        }

        /*
           William Andres Vasquez Sanabria 
           Versión 1.0
           context: RegistrarCliente: ActualizarCliente(nombre:string,apellido:string,cedula:int,fechadenacimiento:date,correo:string,
           contraseña:string,codigo:int):void
           pre: ConsultarCliente haya sido invocado previamente
           pro: Cliente es actualizado en DB
           */
        public void ActualizarCliente(int codigo,string nombre, string apellido,  DateTime fechaDeNacimiento, int cedula,
            string correo, string contraseña)
        {
            ActualizarClienteRepositorio(codigo, nombre, apellido,  fechaDeNacimiento, cedula, correo, contraseña);
            System.Console.WriteLine("El cliente ha sido Actualizado");
        }

        /*
           William Andres Vasquez Sanabria 
           Versión 1.0
           context: ConsultarCliente: ActualizarCliente(nombre:string,apellido:string,cedula:int):void
           pre: RecuperarClientes() > 0, 
           pro: Cliente es actualizado en DB
           */

        public List<Cliente> ConsultarCliente(string nombre, string apellido, int cedula)
        {
            List<Cliente> clientesAux = new List<Cliente>();
            clientes = RecuperarClientes();
            if (clientes.Count > 0)
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
            else {
                //lanzarExcepcion de no hay clientes para consultar
                System.Console.WriteLine("No se encontraron registros de clientes");
            }
            if (clientesAux.Count == 0) {
                //lanzarExcepcion de no se encontraron coincidencias
                System.Console.WriteLine("No se encontraron coincidencias");
            }
            return clientesAux;
        }

        /*
         William Andres Vasquez Sanabria 
         Versión 1.0
         context: EliminarCliente: ActualizarCliente(codigo:int):void
         pre: ConsultarCliente haya sido invocado previamente
         pro: Cliente es eliminado en DB , RecuperarClientes.Count  = RecuperarClientes.Count - 1
         */

        public void EliminarCliente(int codigo)
        {
            EliminarClienteRepositorio(codigo);
            System.Console.WriteLine("El cliente ha sido eliminado");
        }

        /*
         este método recupera de la db los clientes en sumo
         */
        public List<Cliente> RecuperarClientes() {
            List<Cliente> clientesAux = new List<Cliente>();
            List<string[]> aux = RecuperarClientesRepositorio();
            if (aux.Count > 0)
            {
                for (int i = 0; i < aux.Count; i++)
                {
                    clientesAux.Add(new Cliente(Int32.Parse(aux[i][0]),aux[i][1], aux[i][2], DateTime.Parse(aux[i][3]), 
                        Int32.Parse(aux[i][4]), aux[i][5], aux[i][6]));
                }
            }
            else {
                Console.WriteLine("No se encontraron Clientes");
            }
            return clientesAux;
        }
    }
}
