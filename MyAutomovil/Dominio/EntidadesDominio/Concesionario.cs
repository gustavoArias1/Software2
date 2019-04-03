using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    public class Concesionario
    {
        private int codigo; 
        private string nombreConcesionario;
        private string nombreAdministrador;
        private string direccion;
        private string telefono;
        private string ciudad;
        public List<Vendedor> vendedores = null;
        public List<Vehiculo> vehiculos = null;

        public Concesionario(string nombreConcesionario, string administrador, string direccion, string telefono, string ciudad)
        {
            this.nombreConcesionario = nombreConcesionario;
            this.nombreAdministrador = administrador;
            this.direccion = direccion;
            this.telefono = telefono;
            this.ciudad = ciudad;
        }
        public Concesionario(int codigo, string nombreConcesionario, string administrador, string direccion, string telefono, string ciudad)
        {
            this.nombreConcesionario = nombreConcesionario;
            this.nombreAdministrador = administrador;
            this.direccion = direccion;
            this.telefono = telefono;
            this.ciudad = ciudad;
            this.codigo = codigo;
            this.vendedores = new List<Vendedor>();
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string NombreConcesionario { get => nombreConcesionario; set => nombreConcesionario = value; }
        public string Direccion { get => direccion; set => direccion = value; }
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


         public List<Vendedor> RecuperarVehiculos() {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            /*
             Consulta DB
             */
            return vendedoresAux;
        }
    }
}
