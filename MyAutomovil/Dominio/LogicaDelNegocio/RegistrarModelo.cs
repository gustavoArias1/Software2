﻿using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Text;
using Persistencia;

namespace Dominio.LogicaDelNegocio
{


    /*
    * La clase registrar modelo hara operaciones dml sobre las modelos del sistema realizando verificaciones de datos
    * @ Yherson Blandon
    * @ version 2.0 04/04/2019
    */
   public  class RegistrarModelo : ConexionBaseDatos
    {
        public List<Modelo> modelos = new List<Modelo>();

        public RegistrarModelo()
        {
            Conectar();
        }



        /*
       * El metodo AdicionarModelo agrega un nuevo modelo en la base de datos consultando si dicho modelo no existe.
       * @ Yherson Blandon
       * @ version 2.0 04/04/2019
       context RegistrarModelo :: AdicionarModelo
       pre: ConsultarModelo(nombreModelo, nombreMarca) and nombreModelo != null and nombreMarca != null and numeroPuertas !=null cilindraje
       != null  transmision != null
       post: ConsultarModelo(nombreModelo, nombreMarca) or  self@!nombreModelo.Exception or self@!nombreMarca.Exception or self@!numeroPuertas.Exception
       or self@!cilindraje.Exception or self@!transmision.Exception 
       */
        public Boolean AdicionarModelo(string nombreModelo, string nombreMarca, int numeroPuertas, string cilindraje, string transmision)
        {
            Boolean adicionado = false;
            // AdicionarModelosRepositorio(nombreModelo, nombreMarca, numeroPuertas, cilindraje, transmision);
            modelos.Clear();
            ConsultarModelov();
            Modelo modelo = new Modelo { nombreModelo = nombreModelo, nombreMarca = nombreMarca, numeroPuertas = numeroPuertas, cilindraje = cilindraje, transmision = transmision };
            Boolean existe=false;
            for (int i = 0; i < modelos.Count; i++)
            {
                if (modelos[i].nombreModelo.Equals(nombreModelo) && modelos[i].nombreMarca.Equals(nombreMarca))
                {
                    existe = true;

                }

            }
            if (!existe)
            {
                adicionado = true;
                AdicionarModelosRepositorio(nombreModelo, nombreMarca, numeroPuertas, cilindraje, transmision);
            }
            else
            {
                adicionado = false;
                Console.WriteLine("el modelo ya existe en la base de datos");

            }
            return adicionado;

        }

        /*
        * El metodo ActualizarModelo actualizara los datos de un modelo especifico modificando sus atributos
        * @ Yherson Blandon
        * @ version 2.0 04/04/2019
        context RegistrarModelo :: ActualizarModelo
        pre: ConsultarModelo(nombreModelo, nombreMarca) and nombreModelo != null and nombreMarca != null and numeroPuertas !=null cilindraje
        != null  transmision != null
        post: ConsultarModelo(nombreModelo, nombreMarca) or  self@!nombreModelo.Exception or self@!nombreMarca.Exception or self@!numeroPuertas.Exception
        or self@!cilindraje.Exception or self@!transmision.Exception 
        */
        public Boolean ActualizarModelo(string nombreModelo, string nombreMarca, int numeroPuertas, string cilindraje, string transmision)
        {
            modelos.Clear();
            ConsultarModelov();
            Modelo modelo = new Modelo { nombreModelo = nombreModelo, nombreMarca = nombreMarca, numeroPuertas = numeroPuertas, cilindraje =cilindraje, transmision = transmision };
            Boolean existe = false;

            for (int i = 0; i < modelos.Count; i++)
            {
                if (modelos[i].nombreModelo.Equals(nombreModelo) && modelos[i].nombreMarca.Equals(nombreMarca) )
                {
                    existe = true;

                }
            }
            if (existe)
            {
                ActualizarModelosRepositorio(nombreModelo, nombreMarca, numeroPuertas, cilindraje, transmision);
                return existe;
            }
            else
            {
                return existe;
            }
        }
     

        

            /*
             * El metodo ConsultarModelo consulta una modelo especifico de la base de datos en caso de que no exista mostrara un mensaje de error
             * @ Yherson Blandon
             * @ version 2.0 04/04/2019
             context RegistrarModelo :: ConsultarModelo
             pre: nombreModelo != null and nombreMarca =! null
             post: ConsultarModelo(nombreModelo, nombreMarca) or self@!nombreModelo.Exception or self@!nombreMarca.Exception
             */
            public Modelo ConsultarModelo(string nombreModelo, string nombreMarca)
            {

            // acceso a la base de datos para extraer modelos
            modelos.Clear();
            RecuperarModelos();
            Modelo modelo = null;
            try
            {
                for (int i = 0; i < modelos.Count; i++)
                {
                    if ((modelos[i].nombreModelo.Equals(nombreModelo) ))
                    {
                        modelo = modelos[i];
                    }

                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);

            }
            if (modelo == null)
            {
                Console.WriteLine("campo vacio");
            }
            return modelo;
        }

        public void ConsultarModelov()
        {
            modelos.Clear();
            foreach (string[] x in ConsultarModelosRepositorio())
            {
                modelos.Add(new Modelo { nombreModelo = x[0], nombreMarca = x[1], numeroPuertas = Int32.Parse(x[2]), cilindraje = x[3], transmision = x[4]});
            }
        }


        /*
         * El metodo Eliminarmodelo elimina un modelo especifico de la base de datos.
         * @ Yherson Blandon
         * @ version 2.0 04/04/2019
         context RegistrarModelo:: Eliminarmodelo
         pre: ConsultarModelo(nombreModelo,nombreMarca)
         post: !ConsultarModelo(nombreModelo,nombreMarca) or self@pre.ConsultarModelo(nombreModelo, nombreMarca)
         */
        public void Eliminarmodelo(string nombreModelo)
        {
            EliminarModeloRepositorio(nombreModelo);
            Console.WriteLine("modelo eliminado");
        }

        public void RecuperarModelos()
        {

            List<Modelo> aux = new List<Modelo>();
            foreach (string[] x in ConsultarModelosRepositorio())
            {
                this.modelos.Add(new Modelo { nombreModelo = x[0], nombreMarca = x[1], numeroPuertas = Int32.Parse(x[2]), cilindraje = x[3], transmision = x[4] });
            }

        }
    }
}
