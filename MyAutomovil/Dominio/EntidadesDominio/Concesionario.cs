using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    class Concesionario
    {
        private int codigo; 
        private string nombreConcesionario;
        private Administrador administrador;
        private string fecha;
        private string telefono;
        private string ciudad;
        List<Vendedor> vendedores = null;

        public Concesionario(string nombreConcesionario, Administrador administrador, string fecha, string telefono, string ciudad)
        {
            this.nombreConcesionario = nombreConcesionario;
            this.administrador = administrador;
            this.fecha = fecha;
            this.telefono = telefono;
            this.ciudad = ciudad;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string NombreConcesionario { get => nombreConcesionario; set => nombreConcesionario = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        internal Administrador Administrador { get => administrador; set => administrador = value; }

        private List<Vendedor> RecuperarEmpleados(Concesionario concesionario) {
            List<Vendedor> vendedoresAux = null;
            /*
             Consulta DB
             */
            return vendedoresAux;
        }


    }
}
