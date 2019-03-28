using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.LogicaDelNegocio
{
    class RegistrarConcesionario
    {
        List<Concesionario> Concesionarios = new List<Concesionario>();
        public void AdicionarConcesionario(string nombreConcesionario, Administrador administrador, string direccion, 
            string telefono, string ciudad)
        {
            //acceso a la base de datos recuperarConcesionario
            Concesionario concesionario = new Concesionario(nombreConcesionario, administrador, direccion,telefono,ciudad);
            if (Concesionarios.Contains(concesionario))
            {
                //exception
            }
            else
            {
                //agregar en la base de datos
            }

        }

        public void ActualizarConcesionario(string nombreConcesionario, Administrador administrador, string direccion,
            string telefono, string ciudad)
        {
            //llamado de metodo de persistencia para hacer un update en la base de datos
        }

        public Concesionario ConsultarConcesionario(string nombreConcesionario)
        {
            // Accsesos a la base de datos por medio del metodo recuperarConcesionario
            //exception 
            Concesionario concesionario = null;
            try
            {
                for (int i = 0; i < Concesionarios.Count; i++)
                {
                    if (Concesionarios[i].NombreConcesionario.Equals(nombreConcesionario))
                    {
                        concesionario = Concesionarios[i];
                    }
                }
            }
            catch(Exception ex)
            {
              // exception
            }
            if (concesionario == null)
            {
                //exception

            }
            

            return concesionario;
        }
        public List<Concesionario> ConsultarConcesionarios()
        {
            // Accsesos a la base de datos por medio del metodo recuperarConcesionario
            //exception 

            return null;
        }

        public void EliminarConcesionario(string nombreConcesionario)
        {
            //llamado del metodo de persisntencia para elimianr un concesionario por medio del codigo
        }
        public List<Concesionario> RecuperarConcesionario()
        {
            //llamado al metodo de persitencia que obiene la lista de concesionarios
            return null;
        }
    }
}
