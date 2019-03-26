using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.LogicaDelNegocio
{
     
    class RegistrarModelo
    {
        List<Modelo> modelos = new List<Modelo>();

        public void AdicionarModelo(string nombreModelo,string nombreMarca,int numeroPuertas,string cilindraje,string transmision)
        {
            //metodo modelo para acceso a base de datos nueva variable 
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
        public void ActualizarModelo(string nombreModelo, string nombreMarca, int numeroPuertas, string cilindraje, string transmision)
        {
            //Acceso base de datos enviando nombreMerca, pais con sentencia update;
        }



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



        public void Eliminarmodelo(string nombreModelo)
        {
            //Acceso base de datos enviando delete
            //Exception  
        }

        public List<Modelo> RecuperarModelos()
        {
            //acceso a la base de datos
            return null;
        }

    }
}
