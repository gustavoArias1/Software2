using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesDominio;
using Persistencia;

namespace Dominio.LogicaDelNegocio
{
    class RegistrarCompraUsado : ConexionBaseDatos
    {

        public RegistrarCompraUsado()
        {
            Conectar();
        }

        /*
     * El metodo AdicionarCompra adiciona un nuevo registro de prospecto de compra en la base de datos.
     * @ Yherson Blandon
     * @ version 4.0 05/04/2019
     context RegistrarComprarUsado :: AdicionarCompra
      pre: AdicionarCompra(nombreConcesionario, fechaCompra, precioCompra, placa,codigoProveedor) and nombreConcesionario != null and fechaCompra!= null  and precioCompra !=null and placa !=null codigoProveedor
       != null  transmision != null
       post: AdicionarCompra(nombreConcesionario, fechaCompra, precioCompra, placa,codigoProveedor) or  self@!nombreConcesionario.Exception or self@!fechaCompra.Exception or self@!precioCompra.Exception
       or self@!placa.Exception or self@!codigoProveedor.Exception 
     */
        public void AdicionarCompra(string nombreConcesionario, DateTime fechaCompra, double precioCompra, string placa,
            int codigoProveedor)
        {
            Compra aux = new Compra(nombreConcesionario, fechaCompra, precioCompra, placa, codigoProveedor);
            Concesionario c = RecuperarConcesionario(nombreConcesionario);
            AdicionarCompraRepositorio(nombreConcesionario, fechaCompra, precioCompra, placa, codigoProveedor);
         
            //if (c != null)
            //{
            //    c.compras = c.RecuperarCompras();
            //    if (c.compras.Contains(aux))
            //    {
            //        Console.WriteLine("ya existe una factura con estos datos");
            //    }
            //    else
            //    {
            //        AdicionarCompraRepositorio(nombreConcesionario, fechaCompra, precioCompra, placa, codigoProveedor);
            //    }
            //}
        }


        /*
    * El metodo RecuperarConcesionario extrae la lista de compras realizadas en in determinado concesionario.
    * @ Yherson Blandon
    * @ version 4.0 05/04/2019
    context RegistrarComprarUsado :: RecuperarConcecionario
     pre: AdicionarCompra(nombreConcesionario) and nombreConcesionario != null 
      post: AdicionarCompra(nombreConcesionario) or  self@!nombreConcesionario.Exception  
    */
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