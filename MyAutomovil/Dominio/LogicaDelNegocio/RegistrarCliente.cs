using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Text;
using Persistencia;

namespace Dominio.LogicaDelNegocio
{
    public class RegistrarCliente : ConexionBaseDatos
    {
        public List<Cliente> clientes = new List<Cliente>();

        public RegistrarCliente()
        {
            Conectar();
        }



        /*
         William Andres Vasquez Sanabria 
         Versión 1.0
         context: RegistrarCliente: AdcionarCliente(nombre:string,apellido:string,cedula:int,fechadenacimiento:date,correo:string,
         contraseña:string):void
         pre: RecuperarClientes.Count > 0, clientes.Contains(cliente) != true
         pro: Cliente es agregado en DB, RecuperarClientes.Count  = RecuperarClientes.Count + 1
             */
        public Boolean AdicionarCliente(string nombre, string apellido, int cedula, DateTime fechaDeNacimiento,
            string correo, string contraseña)
        {
            clientes = RecuperarClientes();
            Cliente cliente = new Cliente { nombre = nombre, apellido = apellido, fechaDeNacimiento = fechaDeNacimiento, cedula = cedula, correo = correo, contraseña = contraseña };
            if (clientes.Count > 0)

            {
                if (clientes.Contains(cliente))
                {
                    //lanza execepcion indica que el cliente ya existe
                    return false;
                }
                else
                {
                    AdicionarClienteRepositorio(nombre, apellido, fechaDeNacimiento, cedula, correo, contraseña);
                    return true;
                }
            }
            else
            {

                AdicionarClienteRepositorio(nombre, apellido, fechaDeNacimiento, cedula, correo, contraseña);
                return true;

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
        public Boolean ActualizarCliente(int codigo, string nombre, string apellido, int cedula, DateTime fechaDeNacimiento,
            string correo, string contraseña)
        {
            Boolean Actualizado = false;
            Boolean existe = false;
            clientes.Clear();
            clientes=RecuperarClientes();
            for (int i = 0; i < clientes.Count; i++)
            {

                if (clientes[i].codigo.Equals(codigo))   {
                    existe = true;
                    break;
                }
            
            }
            if (existe)
            {
                Actualizado = true;
                ActualizarClienteRepositorio(codigo, nombre, apellido, fechaDeNacimiento, cedula, correo, contraseña);
                System.Console.WriteLine("El cliente ha sido Actualizado");
            }
            else
            {
                Actualizado = false;
                System.Console.WriteLine("El cliente no ha sido Actualizado");

            }
            return Actualizado;
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
            Console.WriteLine("entroo");
            List<Cliente> clientesAux = new List<Cliente>();
            clientes = RecuperarClientes();
            if (clientes.Count > 0)
            {
                for (int i = 0; i < clientes.Count; i++)
                {
                    if (clientes[i].nombre.Equals(nombre) || clientes[i].apellido.Equals(apellido) ||
                            clientes[i].cedula == cedula)
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

        public List<Cliente> ConsultarCliente() {
            return RecuperarClientes();
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

            int Codigo = 0;
            string Nombre = "";
            string Apellido = "";
            DateTime Fecha;
            int Cedula = 0;
            string Correo = "";
            string Contraseña = "";
            if (aux.Count > 0)
            {
                for (int i = 0; i < aux.Count; i++)
                {
                    

                    String Codigo2 = (string)aux[i].GetValue(0);
                    String Cedula2 =(string)aux[i].GetValue(4);
                    if (Cedula2.Length > 10)
                    {
                        Cedula2 = Cedula2.Substring(0, 9);
                    }
                    String Fecha2=(string)aux[i].GetValue(3);
                    Codigo = Convert.ToInt32(Codigo2);
                    Nombre = (string)aux[i].GetValue(1);
                    Apellido= (string)aux[i].GetValue(2);
                    Fecha = Convert.ToDateTime(Fecha2);
                    Cedula= Int32.Parse(Cedula2);
                    Correo=(string)aux[i].GetValue(5);
                    Contraseña = (string)aux[i].GetValue(6);

                    clientesAux.Add(new Cliente { nombre = Nombre, apellido = Apellido, fechaDeNacimiento = Fecha, cedula = Cedula, correo = Correo, contraseña = Contraseña });
                }
            }
            else {
                Console.WriteLine("No se encontraron Clientes");
            }
            return clientesAux;
        }
    }
}
