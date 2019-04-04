using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    public class Compra
    {
        private string concesionario;
        private string cedula;
        private string nombreProveedor;
        private string apellidoProveedor;
        private DateTime fecha;
        private string marca;
        private string modelo;
        private string precio;
        private string placa;

        public Compra(string concesionario, string cedula, string nombreProveedor, string apellidoProveedor,
            DateTime fecha, string marca, string modelo, string precio,string placa)
        {
            this.concesionario = concesionario;
            this.cedula = cedula;
            this.nombreProveedor = nombreProveedor;
            this.apellidoProveedor = apellidoProveedor;
            this.fecha = fecha;
            this.marca = marca;
            this.modelo = modelo;
            this.precio = precio;
            this.placa = placa;
        }

        public string Concesionario { get => concesionario; set => concesionario = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string NombreProveedor { get => nombreProveedor; set => nombreProveedor = value; }
        public string ApellidoProveedor { get => apellidoProveedor; set => apellidoProveedor = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Precio { get => precio; set => precio = value; }
        public string Placa { get => placa; set => placa = value; }
    }
}
