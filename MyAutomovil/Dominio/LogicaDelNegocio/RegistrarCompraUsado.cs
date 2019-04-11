using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesDominio;
using Persistencia;

namespace Dominio.LogicaDelNegocio
{
    class RegistrarCompraUsado : DBFake
    {
        public void AdicionarCompra(string nombreConcesionario, DateTime fechaCompra, string precioCompra, string placa,
            int codigoProveedor)
        {
            Compra aux = new Compra(nombreConcesionario, fechaCompra, precioCompra, placa, codigoProveedor);
            Concesionario c = RecuperarConcesionario(nombreConcesionario);
            c.compras = c.RecuperarCompras();
            if (c.compras.Contains(aux))
            {
                Console.WriteLine("ya existe una factura con estos datos");
            }
            else
            {

            }
        }

        public Concesionario RecuperarConcesionario(string nombreConcesionario) {
            Concesionario c;
            string[] aux = RecuperarConcesionarioRepositorio(nombreConcesionario);
            if (aux == null)
            {
                return null;
            }
            else
            {
                c = new Concesionario(Int32.Parse(aux[0]), aux[1], aux[2], aux[3], aux[4], aux[5]);
            }
            return c;
        }
        public void ConsultarCompra(string codigo)
        {

        }

    }
}