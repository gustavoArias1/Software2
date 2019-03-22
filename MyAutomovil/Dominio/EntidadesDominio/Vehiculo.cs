using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    class Vehiculo
    {
        private string placa;
        private Marca marca;
        private Modelo modelo;
        private string año;
        private string numeroChasis;
        private string color;
        private string concesionario;

        public Vehiculo(string placa, Marca marca, Modelo modelo, string año, string numeroChasis, string color, string concesionario)
        {
            this.placa = placa;
            this.marca = marca;
            this.modelo = modelo;
            this.año = año;
            this.numeroChasis = numeroChasis;
            this.color = color;
            this.concesionario = concesionario;
        }

        public string Placa { get => placa; set => placa = value; }
        public string Año { get => año; set => año = value; }
        public string NumeroChasis { get => numeroChasis; set => numeroChasis = value; }
        public string Color { get => color; set => color = value; }
        public string Concesionario { get => concesionario; set => concesionario = value; }
        internal Marca Marca { get => marca; set => marca = value; }
        internal Modelo Modelo { get => modelo; set => modelo = value; }
    }
}
