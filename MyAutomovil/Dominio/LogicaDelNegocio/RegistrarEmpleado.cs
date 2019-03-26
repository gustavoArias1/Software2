using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.LogicaDelNegocio
{
    class RegistrarEmpleado
    {
        List<Vendedor> vendedores = null;

        public void AdicionarEmpleado(string nombre,string apellido, int cedula,string cargo, DateTime fechanacimiento,
            string nombreConcesionario)
        {
            Concesionario concesionario = RecuperarConcesionario(nombreConcesionario);
            concesionario.vendedores = concesionario.RecuperarEmpleados();
            Vendedor vendedor = new Vendedor(nombre,apellido,cedula,cargo,fechanacimiento,nombreConcesionario);
            if (concesionario.vendedores.Contains(vendedor))
            {
                /*
                excepcion, ya existe el vendedor    
             */
            }
            else {
                /*
                creamos el vendedor en la base de datos
                
                excepcion ya se ha creado el vendedor
             */
            }
        }
         
        public void EliminarEmpleado(int codigo)
        {
            /*
             eliminar empleado en DB con sentencia delete
             */
        }
        public void ActualizarEmpleado(string nombre, string apellido, int cedula, string cargo, DateTime fechanacimiento,
            Concesionario concesionario,string correo,string contraseña)
        {
            /*
             actualizar empleado con sentencia update
             */
        }

        public List<Vendedor> ConsultarEmpleado(int cedula, string nombre,string apellido,string nombreConcesionario)
        {   /*
            @vendedoresAux lista que retornaremos con los empleados
             */
            List<Vendedor> vendedoresAux = new List<Vendedor>();

            Concesionario concesionario = RecuperarConcesionario(nombreConcesionario);
            concesionario.vendedores = concesionario.RecuperarEmpleados();
            try
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
            catch (Exception ex) {
                //excepcion
            }
            if (concesionario.vendedores.Count == 0) {
                //excepcion no hay coincidencias
                return null;
            }
            return vendedoresAux;
        }

        public List<Vendedor> ConsultarEmpleado(string nombreConcesionario)
        {
            Concesionario concesionario = RecuperarConcesionario(nombreConcesionario);
            concesionario.vendedores = concesionario.RecuperarEmpleados();
            return concesionario.vendedores;
        }

        /*
         retorna todos los empleados del sistema
             */
        public List<Vendedor> RecuperarEmpleados()
        {
            List<Vendedor> vendedoresAux = new List<Vendedor>();
            /*
             recuperar datos de la DB
             */
            return vendedoresAux;
        }

        /*
         Busca un objeto concesionario
             */
        private Concesionario RecuperarConcesionario(string nombreconcesionario)
        {
            Concesionario c = null;

            /*
            aqui viene la extraccion de la DB del concesionario

            c = new Concesionario();
             */
            return c;
        }


    }
}
