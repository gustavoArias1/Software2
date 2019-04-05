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
        private int idReclamo;
        private int idCliente;
        private int idAdministrador;

        public Reclamo(int idReclamo, string tipoReclamo, string concesionario, string descripcion, int idCliente)
        {
            this.idReclamo = idReclamo;
            this.tipoReclamo = tipoReclamo;
            this.concesionario = concesionario;
            this.descripcion = descripcion;
            this.idCliente = idCliente;
        }

        public Reclamo(int idReclamo, string tipoReclamo, string concesionario, string descripcion, int idCliente, string solucionReclamo, int idAdministrador)
        {
            this.idReclamo = idReclamo;
            this.tipoReclamo = tipoReclamo;
            this.concesionario = concesionario;
            this.descripcion = descripcion;
            this.idCliente = idCliente;
            this.solucionReclamo = solucionReclamo;
            this.idAdministrador = idAdministrador;
        }

        public string TipoReclamo { get => tipoReclamo; set => tipoReclamo = value; }
        public string Concesionario { get => concesionario; set => concesionario = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string SolucionReclamo { get => solucionReclamo; set => solucionReclamo = value; }
        public int IdReclamo { get => idReclamo; set => idReclamo = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdAdministrador { get => idAdministrador; set => idAdministrador = value; }
    }
}
