using Dominio.EntidadesDominio;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.LogicaDelNegocio
{
    /*
     Esta clase sirve basicamente como un crud de concesionario ya que sirve para registrar,consultar,update y eliminar 
     un concesionario de la base de datos 
     @ Gustavo Andres Arias Loaiza
     @ 04/04/2019
     */
    class RegistrarConcesionario : DBFake
    {
        public List<Concesionario> Concesionarios = new List<Concesionario>();
        String concecionario = "";

       

        /*context RegistrarConcesionario::AdicionarConcesionario(nombreConcesionario,administrador,direccion, 
            telefono,ciudad)
           pre : !Concesionarios.contains(concesionario)
           post: Consultar(nombreConcesionario)
         */
        public void AdicionarConcesionario(string nombreConcesionario, String administrador, string direccion, 
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
                //agregar en la base datos un concesionario
            }

        }

        /*context RegistrarConcesionario::ActualizarConcesionario
         *pre :  Consultar(nombreConcesionario) and nombreConcesionario !=null
         *post : Consultar(nombreConcesionario) 
         */
        public void ActualizarConcesionario(string nombreConcesionario, Administrador administrador, string direccion,
            string telefono, string ciudad)
        {
            //llamado de metodo de persistencia para hacer un update en la base de datos
        }



        /* Context RegistrarConcesionario :: ConsultarConcesionario 
         * pre :  
         */
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
                //excepcion
                Console.WriteLine(ex);
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
        public void RecuperarConcesionarios()
        {
            
            //llamado al metodo de persitencia que obiene la lista de concesionarios
            foreach (string[] x in ConsultarConcesionariosRepositorio()) {
      
                   this.Concesionarios.Add(new Concesionario(Int32.Parse(x[0]), x[1], x[2], x[3], x[4], x[5]));
            }
  
        }
    }
}
