using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.LogicaDelNegocio
{
    class SolicitarSoporte
    {
        List<Reclamo> reclamos = null;
        public void AdicionarReclamo(String tipoReclamo,string concesionario,string descripcion)
        {
            reclamos = ConsularReclamo();
            //Invocar metodo de adicion en la base de persistencia.
        }
        public List<Reclamo> ConsularReclamo()
        {
            //Obtner lista de reclamos de la base de datos.
            return reclamos;
        }

        public Reclamo SolucionarReclamo(Reclamo reclamo, string solucionReclamo)
        {
            reclamo.SolucionReclamo = solucionReclamo;
            return reclamo;
        }
    }
}
