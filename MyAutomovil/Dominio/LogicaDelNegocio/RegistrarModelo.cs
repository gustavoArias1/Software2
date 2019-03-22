using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.LogicaDelNegocio
{
     
    class RegistrarModelo
    {
        public void AdicionarModelo(string nombreModelo,string nombreMarca,int numeroPuertas,string cilindraje,string transmision)
        {

        }
        public void ActualizarModelo(string nombreModelo, string nombreMarca, int numeroPuertas, string cilindraje, string transmision)
        {

        }
        public LinkedList<Modelo> ConsultarModelo(string nombreModelo,string nombreMarca)
        {
            Modelo modelo = null;
           
            

            LinkedList<Modelo> lista = new LinkedList<Modelo>();
            return lista;    
        }

        public void Eliminarmodelo(string nombreModelo)
        {

        }



    }
}
