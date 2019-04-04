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
     @ version 2.0 04/04/2019
     */
    class RegistrarConcesionario : DBFake
    {
        public List<Concesionario> Concesionarios = new List<Concesionario>();
        string concecionario = "";



        /* Este metodo sirve para agregar un nuevo concesionario a la base de datos
         * @ Gustavo Andres Arias
         * @ version 2.0 04/04/2019
         * context RegistrarConcesionario::AdicionarConcesionario(nombreConcesionario,administrador,direccion, telefono,ciudad)
         * pre : !Concesionarios.contains(concesionario)
         * post: Consultar(nombreConcesionario)
         */
        public void AdicionarConcesionario(string nombreConcesionario, String administrador, string direccion, 
            string telefono, string ciudad)
        {
            RecuperarConcesionarios();

            Concesionario concesionario = new Concesionario(nombreConcesionario, administrador, direccion,telefono,ciudad);
            if (Concesionarios.Contains(concesionario))
            {
                System.Console.WriteLine("ERROR CONCESIONARIO YA REGISTRADO");
            }
            else
            {
                System.Console.WriteLine("CONCESIONARIO REGISTRADO");
                AdicionarConcesionarioRepositorio(this.Concesionarios.Count + 1, nombreConcesionario, administrador, direccion, telefono, ciudad);
            }

        }

        /* Este metodo nos ayuda a actualizar un concesionario existente en la base de datos
         *@ Gustavo Andres  Arias Loaiza
         *@ version 2.0 04/04/2019 
         *context RegistrarConcesionario::ActualizarConcesionario
         *pre :  Consultar(nombreConcesionario) and nombreConcesionario !=null
         *post : Consultar(nombreConcesionario) 
         */
        public void ActualizarConcesionario(string nombreConcesionario, Administrador administrador, string direccion,
            string telefono, string ciudad)
        {
            //llamado de metodo de persistencia para hacer un update en la base de datos
        }



        /* Este metodo nos ayuda a obtener la infromacion de un concesionario especifico filtrado por el nombre
         * @ Gustavo Andres Arias
         * @ version 2.0 04/04/2019
         * Context RegistrarConcesionario :: ConsultarConcesionario 
         * pre : nombreConcesionario != null
         * post: ConsultarConcesionario 
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

        /* Este metodo nos ayuda a obtener la informacion de todos los  concesionarios en la base de datos
        * @ Gustavo Andres Arias
        * @ version 2.0 04/04/2019
        * Context RegistrarConcesionario :: ConsultarConcesionarios 
        * post: ConsultarConcesionario() 
        */

        public List<Concesionario> ConsultarConcesionarios()
        {
            // Accsesos a la base de datos por medio del metodo recuperarConcesionario
            //exception 

            return null;
        }

        /* Este metodo nos permite eliminar un Concesionario de la base de datos 
         * @ Gustavo Andres Arias
         * @ version 2.0 04/04/2019
         * context : RegistarConcesionario :: EliminarConcesionario
         * pre : ConsultarConcesionario(nombreConcesionario)
         * post: !ConsultarConcesionario(NombreConcesionario ) or self@pre.ConsultarConcesionario(nombreConcesionario) 
         */
        public void EliminarConcesionario(string nombreConcesionario)
        {
            //llamado del metodo de persisntencia para elimianr un concesionario por medio del codigo
        }

        /* Este metodo nos permite traer los datos de un concesioanrio  de la base de datos
         * @ Gustavo Andres Arias
         * @ version 2.0 04/04/2019
         * context : RegistrarConcesionario :: RecuperarConcesionario
         * pre  : 
         * post :
         */
        public void RecuperarConcesionarios()
        {
            
            //llamado al metodo de persitencia que obiene la lista de concesionarios
            foreach (string[] x in ConsultarConcesionariosRepositorio())
            {
                   this.Concesionarios.Add(new Concesionario( x[1], x[2], x[3], x[4], x[5]));
            }
  
        }
    }
}
