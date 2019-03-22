using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    class Concesionario
    {
        private string nombreConcesionario;
        private Administrador administrador;
        private string fecha;
        private string telefono;
        private string ciudad;

        public Concesionario(string nombreConcesionario, Administrador administrador, string fecha, string telefono, string ciudad)
        {
            this.nombreConcesionario = nombreConcesionario;
            this.administrador = administrador;
            this.fecha = fecha;
            this.telefono = telefono;
            this.ciudad = ciudad;
        }
    }
}
