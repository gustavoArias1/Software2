using Dominio.EntidadesDominio;
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
    class RegistrarModelo : DBFake
    {
        List<Modelo> modelos = new List<Modelo>();


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
        public void AdicionarModelo(string nombreModelo,string nombreMarca,int numeroPuertas,string cilindraje,string transmision)
        {
            AdicionarModelosRepositorio(nombreModelo, nombreMarca, numeroPuertas, cilindraje, transmision);
           Modelo modelo = new Modelo(nombreModelo, nombreMarca, transmision,numeroPuertas, cilindraje);
            if (modelos.Contains(modelo))
            {
                //exception
            }
            else
            {
                modelos.Add(modelo);
            }

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
        public void ActualizarModelo(string nombreModelo, string nombreMarca, int numeroPuertas, string cilindraje, string transmision)
        {
            ActualizarModelosRepositorio(nombreModelo, nombreMarca, numeroPuertas, cilindraje, transmision);
        }


        /*
         * El metodo ConsultarModelo consulta una modelo especifico de la base de datos en caso de que no exista mostrara un mensaje de error
         * @ Yherson Blandon
         * @ version 2.0 04/04/2019
         context RegistrarModelo :: ConsultarModelo
         pre: nombreModelo != null and nombreMarca =! null
         post: ConsultarModelo(nombreModelo, nombreMarca) or self@!nombreModelo.Exception or self@!nombreMarca.Exception
         */
        public Modelo ConsultarModelo(string nombreModelo,string nombreMarca)
        {
       
            // acceso a la base de datos para extraer modelos
             Modelo modelo = null;
            try
            {
                for (int i = 0; i < modelos.Count; i++)
                {
                    if ((modelos[i].Nombremodelo.Equals(nombreModelo)&& (modelos[i].NombreMarca.Equals(nombreMarca))))
                    {                                                  
                         modelo = modelos[i];
                    }
                        
                }
            }
            catch (Exception exc)
            {
                //exception
               
            }
            if (modelo == null)
            {
                //exception
            }
            return modelo;
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
        }

        public List<Modelo> RecuperarModelos(string nombreModelo)
        {
            /*
            List<Modelo> aux = new List<Modelo>();
            List<string[]> modeloAux = RecuperarModelosRepositorio();
            if (modeloAux.Count > 0)
            {
                for (int i = 0; i < modeloAux.Count; i++)
                {
                    aux.Add(new Modelo(modeloAux[i][0], modeloAux[i][0], modeloAux[i][0], int.Parse(modeloAux[i][0]),
                        modeloAux[i][0], modeloAux[i][0]));
                }
            }*/
            return null;
        }

    }
}
