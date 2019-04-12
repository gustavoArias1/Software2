using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    public class Compra
    {
        private int codigo;
        private string nombreConcesionario;
        private DateTime fechaCompra;
        private double precioCompra;
        private string placa;
        private int codigoProveedor;

        public Compra(string nombreConcesionario, DateTime fechaCompra, double precioCompra, string placa, int codigoProveedor)
        {
            this.NombreConcesionario = nombreConcesionario;
            this.FechaCompra = fechaCompra;
            this.PrecioCompra = precioCompra;
            this.Placa = placa;
            this.CodigoProveedor = codigoProveedor;
        }

        public Compra(int codigo, string nombreConcesionario, DateTime fechaCompra, double precioCompra, string placa, int codigoProveedor)
        {
            this.codigo = codigo;
            this.nombreConcesionario = nombreConcesionario;
            this.fechaCompra = fechaCompra;
            this.precioCompra = precioCompra;
            this.placa = placa;
            this.codigoProveedor = codigoProveedor;
        }

        public string NombreConcesionario { get => nombreConcesionario; set => nombreConcesionario = value; }
        public DateTime FechaCompra { get => fechaCompra; set => fechaCompra = value; }
        public double PrecioCompra { get => precioCompra; set => precioCompra = value; }
        public string Placa { get => placa; set => placa = value; }
        public int CodigoProveedor { get => codigoProveedor; set => codigoProveedor = value; }
        public int Codigo { get => codigo; set => codigo = value; }
    }
}
