using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    public class Reclamo
    {
        private string tipoReclamo;
        private string concesionario;
        private string descripcion;
        private string solucionReclamo;

        public Reclamo(string tipoReclamo, string concesionario, string descripcion, string solucionReclamo)
        {
            this.tipoReclamo = tipoReclamo;
            this.concesionario = concesionario;
            this.descripcion = descripcion;
            this.solucionReclamo = solucionReclamo;
        }

        public string TipoReclamo { get => tipoReclamo; set => tipoReclamo = value; }
        public string Concesionario { get => concesionario; set => concesionario = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string SolucionReclamo { get => solucionReclamo; set => solucionReclamo = value; }
    }
}
