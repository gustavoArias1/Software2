using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    public class Vehiculo
    {
        private string placa;
        private string marca;
        private string modelo;
        private string año;
        private string numeroChasis;
        private string color;
        private string concesionario;
        private double precio;

        public Vehiculo(string placa, string marca, string modelo, string año, string numeroChasis, string color, string concesionario,double precio)
        {
            this.placa = placa;
            this.marca = marca;
            this.modelo = modelo;
            this.año = año;
            this.numeroChasis = numeroChasis;
            this.color = color;
            this.concesionario = concesionario;
            this.precio = precio;
        }

        public string Placa { get => placa; set => placa = value; }
        public string Año { get => año; set => año = value; }
        public string NumeroChasis { get => numeroChasis; set => numeroChasis = value; }
        public string Color { get => color; set => color = value; }
        public string Concesionario { get => concesionario; set => concesionario = value; }
        public double Precio { get => precio; set => precio = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
    }
}
