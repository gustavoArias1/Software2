using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    class Concesionario
    {
        private int codigo; 
        private string nombreConcesionario;
        private String nombreAdministrador;
        private string fecha;
        private string telefono;
        private string ciudad;
        public List<Vendedor> vendedores = null;

        public Concesionario(string nombreConcesionario, string administrador, string fecha, string telefono, string ciudad)
        {
            this.nombreConcesionario = nombreConcesionario;
            this.nombreAdministrador = administrador;
            this.fecha = fecha;
            this.telefono = telefono;
            this.ciudad = ciudad;
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string NombreConcesionario { get => nombreConcesionario; set => nombreConcesionario = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Administrador { get => nombreAdministrador; set => nombreAdministrador = value; }

        public List<Vendedor> RecuperarEmpleados() {
            List<Vendedor> vendedoresAux = new List<Vendedor>();
            /*
             Consulta DB
             */
            return vendedoresAux;
        }


    }
}
