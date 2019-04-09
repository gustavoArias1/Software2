using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    public class Modelo
    {
        private string nombremodelo;
        private string nombreMarca;
        private int numeroPuertas;
        private string cilindraje;
        private string transmision;

        public Modelo(string nombremodelo, string nombreMarca,int numeroPuertas, string cilindraje, string transmision)
        {
            this.nombremodelo = nombremodelo;
            this.nombreMarca = nombreMarca;
            this.numeroPuertas = numeroPuertas;
            this.cilindraje = cilindraje;
            this.transmision = transmision;
        }

        public string Nombremodelo { get => nombremodelo; set => nombremodelo = value; }
        public string NombreMarca { get => nombreMarca; set => nombreMarca = value; }
        public int NumeroPuertas { get => numeroPuertas; set => numeroPuertas = value; }
        public string Cilindraje { get => cilindraje; set => cilindraje = value; }
        public string Transmision { get => transmision; set => transmision = value; }

    }


}
