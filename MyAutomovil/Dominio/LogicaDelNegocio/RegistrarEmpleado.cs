using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Text;
using Persistencia;

namespace Dominio.LogicaDelNegocio
{
    class RegistrarEmpleado : ConexionBaseDatos
    {
        
        List<Vendedor> vendedores;

        public RegistrarEmpleado()
        {
            Conectar();
        }

        /*
        * @William vasquez
        @ version 1.0 05/04/2019
        Adicionar un vehiculo 
        context: RegistrarEmpleado::AdicionarEmpleado(nombre:string,apellido:string,cedula:int,cargo:string,fechaNacimiento:DateTime)
        post: RecuperarEmpleados().Count  = RecuperarEmpleados().Count + 1
        */
        public void AdicionarEmpleado(string nombre,string apellido, int cedula,string cargo, DateTime fechanacimiento,
            string nombreConcesionario)
        {
            Concesionario concesionario = RecuperarConcesionario(nombreConcesionario);
            concesionario.vendedores = concesionario.RecuperarEmpleados();
            Vendedor vendedor = new Vendedor(nombre,apellido,cedula,cargo,fechanacimiento,nombreConcesionario);
            if (concesionario.vendedores.Count > 0)
            {
                if (concesionario.vendedores.Contains(vendedor))
                {
                    /*
                    excepcion, ya existe el vendedor    
                 */
                    Console.WriteLine("Ya existe el vendedor");

                }
                else
                {
                    /*
                    creamos el vendedor en la base de datos
                
                    excepcion ya se ha creado el vendedor
                 */
                    AdicionarEmpleadoRepositorio(nombre,apellido,fechanacimiento,cedula,cargo,nombreConcesionario);
                    System.Console.WriteLine("El empleado ha sido creado");
                }
            }
            else {
                /*
                    Creamos el cliente en la base de datos 
                    lanzamos excepcion indica que el cliente ya fue creado
                 */
                AdicionarEmpleadoRepositorio(nombre, apellido, fechanacimiento, cedula, cargo, nombreConcesionario);
                System.Console.WriteLine("El empleado ha sido creado");
            }
        }
        /*
        * @William vasquez
            @ version 1.0 05/04/2019
            Adicionar un vehiculo 
            context: RegistrarEmpleado::EliminarEmpleado(codigo:int)
            pre: ConsultarEmpleado haya sido previamente invocado
            post: se eliminar un empleado de la DB, RecuperarEmpleados.Count  = RecuperarEmpleados.Count - 1
        */
        public void EliminarEmpleado(int codigo)
        {
            /*
             eliminar empleado en DB con sentencia delete
             */
            EliminarEmpleadoRepositorio(codigo);
        }

       /*
        * @William vasquez
            @ version 1.0 05/04/2019
            Actualzar Empleado 
            context: RegistrarEmpleado::ActualizarEmpleado(codigo:int, nombre:string,apellido:string,cedula:int,cergo:string,
            fechaNacimiento:date,concesionario:string,correo:string,contraseña:string)
            pre: ConsultarEmpleado haya sido previamente invocado
            post: se actualiza un empleado 
        */
        public void ActualizarEmpleado(int codigo,string nombre, string apellido, int cedula, string cargo, DateTime fechanacimiento,
            string concesionario,string correo,string contraseña)
        {
            /*
             actualizar empleado con sentencia update
             */
            ActualizarEmpleadoRepositorio(codigo,nombre,apellido,fechanacimiento,cedula,cargo,correo,contraseña,concesionario);
        }

        /*
      * @William vasquez
          @ version 1.0 05/04/2019
          Actualzar Empleado 
          context: RegistrarEmpleado::ConsultarEmpleado(codigo:int, nombre:string,apellido:string,concesionario:string)
          pre: RecuperarConcesionario(concesionario:string) != null
          post: se envia una lista de empleado con las coincidencias
      */
        public List<Vendedor> ConsultarEmpleado(int cedula, string nombre,string apellido,string nombreConcesionario)
        {   /*
            @vendedoresAux lista que retornaremos con los empleados
             */
            List<Vendedor> vendedoresAux = new List<Vendedor>();

            Concesionario concesionario = RecuperarConcesionario(nombreConcesionario);
            concesionario.vendedores = concesionario.RecuperarEmpleados();
            if (concesionario.vendedores.Count > 0)
            {
                for (int i = 0; i < concesionario.vendedores.Count; i++)
                {
                    if (concesionario.vendedores[i].Cedula == cedula || (concesionario.vendedores[i].Nombre.Equals(nombre)) ||
                            (concesionario.vendedores[i].Apellido.Equals(apellido)))
                    {
                        vendedoresAux.Add(concesionario.vendedores[i]);
                    }
                }
            }
            else {
                //lanzarExcepcion de no hay empleados para consultar
                System.Console.WriteLine("No se encontraron registros de empleados");
            }
            if (concesionario.vendedores.Count == 0) {
                //excepcion no hay coincidencias
                System.Console.WriteLine("No se encontraron coincidencias");
            }
            return vendedoresAux;
        }

        /*
    * @William vasquez
        @ version 1.0 05/04/2019
        Actualzar Empleado 
        context: RegistrarEmpleado::ConsultarEmpleado(concesionario:string)
        post: se envia una lista de empleado con las coincidencias
    */
        public List<Vendedor> ConsultarEmpleado(string nombreConcesionario)
        {
            Concesionario concesionario = RecuperarConcesionario(nombreConcesionario);
            concesionario.vendedores = concesionario.RecuperarEmpleados();
            if (concesionario.vendedores.Count == 0) {
                System.Console.WriteLine("No se encontraron coincidencias");
            }
                return concesionario.vendedores;
        }

        /*
         retorna todos los empleados del sistema
             */
        public List<Vendedor> RecuperarEmpleados()
        {
            List<Vendedor> vendedoresAux = new List<Vendedor>();
            List<string[]>vendedoresAux2 = RecuperarEmpleadosRepositorio();
            if (vendedoresAux2.Count > 0)
            {
                for (int i = 0; i < vendedoresAux2.Count; i++)
                {
                    vendedoresAux.Add(new Vendedor(vendedoresAux2[i][0], vendedoresAux2[i][1], Int32.Parse(vendedoresAux2[i][2]),
                        vendedoresAux2[i][3], DateTime.Parse(vendedoresAux2[i][4]), vendedoresAux2[i][5], vendedoresAux2[i][6],
                        Int32.Parse(vendedoresAux2[i][7]), vendedoresAux2[i][8]));
                }
            }
            else {
                Console.WriteLine("NO se pudo recuperar los empleados");
                return null;
            }
            return vendedoresAux;
        }

        /*
         Busca un objeto concesionario
             */
        public Concesionario RecuperarConcesionario(string nombreConcesionario)
        {
            Concesionario c;
            string[] aux = RecuperarConcesionarioRepositorio(nombreConcesionario);
            if (aux == null)
            {
                return null;
            }
            else
            {
                c = new Concesionario(Int32.Parse(aux[0]), aux[1], Int32.Parse(aux[2]), aux[3], aux[4], aux[5]);
            }
            return c;
        }


    }
}
