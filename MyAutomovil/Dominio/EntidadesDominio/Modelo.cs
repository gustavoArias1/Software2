using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    public class Modelo
    {
        private string nombremodelo;
        private string nombreMarca;
        private string transmision;
        private int numeroPuertas;
        private string cilindraje;

        public Modelo(string nombremodelo, string nombreMarca, string transmision, int numeroPuertas, string cilindraje)
        {
            this.nombremodelo = nombremodelo;
            this.nombreMarca = nombreMarca;
            this.transmision = transmision;
            this.numeroPuertas = numeroPuertas;
            this.cilindraje = cilindraje;
        }

        public string Nombremodelo { get => nombremodelo; set => nombremodelo = value; }
        public string NombreMarca { get => nombreMarca; set => nombreMarca = value; }
        public string Transmision { get => transmision; set => transmision = value; }
        public int NumeroPuertas { get => numeroPuertas; set => numeroPuertas = value; }
        public string Cilindraje { get => cilindraje; set => cilindraje = value; }
    }

    
}
