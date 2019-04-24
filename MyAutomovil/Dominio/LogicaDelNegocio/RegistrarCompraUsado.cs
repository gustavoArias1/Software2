using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesDominio;
using Persistencia;

namespace Dominio.LogicaDelNegocio
{
    class RegistrarCompraUsado : DBFake
    {
        public void AdicionarCompra(string nombreConcesionario, DateTime fechaCompra, double precioCompra, string placa,
            int codigoProveedor)
        {
            Compra aux = new Compra(nombreConcesionario, fechaCompra, precioCompra, placa, codigoProveedor);
            Concesionario c = RecuperarConcesionario(nombreConcesionario);
            if (c != null)
            {
                c.compras = c.RecuperarCompras();
                if (c.compras.Contains(aux))
                {
                    Console.WriteLine("ya existe una factura con estos datos");
                }
                else
                {
                    AdicionarCompraRepositorio(nombreConcesionario, fechaCompra, precioCompra, placa, codigoProveedor);
                }
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
                c = new Concesionario(Int32.Parse(aux[0]), aux[1], Int32.Parse(aux[2]), aux[3], aux[4], aux[5]);
            }
            return c;
        }
        public List<Compra> ConsultarCompra(int codigoCompra,string concesionario)
        {
            List<Compra> aux = new List<Compra>();
            Concesionario c = RecuperarConcesionario(concesionario);
            if (c != null)
            {
                c.compras = c.RecuperarCompras();
                if(c.compras.Count> 0 )
                    for (int i = 0; i < c.compras.Count; i++)
                    {
                        if(c.compras[i].NombreConcesionario.Equals(concesionario) && c.compras[i].Codigo == codigoCompra)
                        {
                            aux.Add(c.compras[i]);
                        }
                    }
            }
            return aux;
        }

    }
}