using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Text;
using Persistencia;

namespace Dominio.LogicaDelNegocio
{
    /*
     * La clase SolicitarSoporte agrega los reclamos de los clientes de acuerdo a un tipo especifico de reclamo a una lista de reclamos
     * para luego ser solucionadios por el administrador.
     * @ Manuel Galvis
     * @ version 1.0 05/04/2019
     context SolicitarSoporte inv: SolucionarReclamo pre ConsultarReclamo()
     */
    class SolicitarSoporte : DBFake
    {
        public List<Reclamo> reclamos = new List<Reclamo>();
        public List<Reclamo> recalmosSolucionados = new List<Reclamo>();

        /*
         context SolicitarSoporte :: AdicionarReclamo
         pre: tipoReclamo != null and concesionario != null
         post: ConsultarReclamo(id)
         */
        public void AdicionarReclamo(String tipoReclamo,string concesionario,string descripcion, int idCliente)
        {
            int idReclamo = 0;
            reclamos.Clear();
            ConsularReclamo();
            idReclamo = reclamos.Count + 1;
            Reclamo reclamo = new Reclamo(idReclamo, tipoReclamo, concesionario, descripcion, idCliente);
            AdicionarReclamoRepositorio(reclamo.IdReclamo, reclamo.TipoReclamo, reclamo.Concesionario, reclamo.Descripcion, reclamo.IdCliente);
        }

        /*
         * En el metodo de consultarReclamos los reclamos de los clientes seran almacaenados en lista de reclamos con los reclamos 
         * almacenados en la base de datos.
         * @ Manuel Galvis
         * @ version 1.0 05/04/2019
         context ConsultarReclamo :: ConsultarReclamo
         post: ConsultarMarca()
         */
        public void ConsularReclamo()
        {
            foreach (string[] x in ConsultarReclamosRepositorio())
            {
                reclamos.Add(new Reclamo(Int32.Parse(x[0]), x[1], x[2], x[3], Int32.Parse(x[4])));
            }
        }

        /*
         * El metodo ConsultarReclamo consulta un reclamo especifico de la base de datos en caso de que no exista mostrara un 
         * mensaje de error
         * @ Manuel Galvis
         * @ version 1.0
         context RegistrarReclamo :: ConsultarReclamo
         pre: idReclamo != null
         post: ConsultarReclamo(idReclamo) or self@!idReclamo.Exception
         */
        public Reclamo ConsultarReclamo(int idReclamo)
        {
            reclamos.Clear();
            ConsularReclamo();
            Reclamo reclamo = null;
            try
            {
                for (int i = 0; i < reclamos.Count; i++)
                {
                    if (reclamos[i].IdReclamo.Equals(idReclamo))
                    {
                        reclamo = reclamos[i];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (reclamo == null)
            {
                Console.WriteLine("El reclamo no existe");
            }
            return reclamo;
        }

        /*
         * El metodo de consultarSolucion consulta los reclamos que ya fueron solucionados por el administrador y seran almacaenados en 
         * lista de reclamosSolucion. 
         * @ Manuel Galvis
         * @ version 1.0 05/04/2019
         context ConsultarReclamo :: ConsultarSolucion
         post: ConsultarSolucion()
         */
        public void ConsularSolucion()
        {
            foreach (string[] x in ConsultarSolucionRepositorio())
            {
                recalmosSolucionados.Add(new Reclamo(Int32.Parse(x[0]), x[1], x[2], x[3], Int32.Parse(x[4]), x[5], Int32.Parse(x[6])));
            }
        }

        /*
         * El metodo ConsultarSolcucion consulta un reclamo especifico de la base de datos en caso de que no exista mostrara un 
         * mensaje de error
         * @ Manuel Galvis
         * @ version 1.0 05/04/2019
         context RegistrarReclamo :: ConsultarSolucion
         pre: idReclamo != null
         post: ConsultarSolucion(idReclamo) or self@!idReclamo.Exception
         */
        public Reclamo ConsultarSolucion(int idReclamo)
        {
            recalmosSolucionados.Clear();
            ConsularSolucion();
            Reclamo reclamo = null;
            try
            {
                for (int i = 0; i < recalmosSolucionados.Count; i++)
                {
                    if (recalmosSolucionados[i].IdReclamo.Equals(idReclamo))
                    {
                        reclamo = recalmosSolucionados[i];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (reclamo == null)
            {
                Console.WriteLine("El reclamo no existe");
            }
            return reclamo;
        }

        /*
         * Metodo que agrega una solucion hecha por el administrador a la lista de reclamos sulucionados.
         * @ Manuel Galvis
         * @ version 1.0 07/05/2019
         context RegistrarReclamo :: SoclucionarReclamos
         pre: ConsultarReclamo(idReclamo)*/
        public void SolucionarReclamo(int idReclamo, string solucionReclamo, int idAministrador)
        {
            Reclamo reclamoaux = ConsultarReclamo(idReclamo);
            AdicionarReclamoSolucionRepositorio(reclamoaux.IdReclamo, reclamoaux.TipoReclamo, reclamoaux.Concesionario, reclamoaux.Descripcion, reclamoaux.IdCliente, solucionReclamo, idAministrador);

        }
    }
}
