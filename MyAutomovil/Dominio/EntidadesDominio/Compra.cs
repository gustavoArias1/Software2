using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    public class Compra
    {
        private string nombreConcesionario;
        private DateTime fechaCompra;
        private string precioCompra;
        private string placa;
        private int codigoProveedor;

        public Compra(string nombreConcesionario, DateTime fechaCompra, string precioCompra, string placa, int codigoProveedor)
        {
            this.NombreConcesionario = nombreConcesionario;
            this.FechaCompra = fechaCompra;
            this.PrecioCompra = precioCompra;
            this.Placa = placa;
            this.CodigoProveedor = codigoProveedor;
        }

        public string NombreConcesionario { get => nombreConcesionario; set => nombreConcesionario = value; }
        public DateTime FechaCompra { get => fechaCompra; set => fechaCompra = value; }
        public string PrecioCompra { get => precioCompra; set => precioCompra = value; }
        public string Placa { get => placa; set => placa = value; }
        public int CodigoProveedor { get => codigoProveedor; set => codigoProveedor = value; }
    }
}
