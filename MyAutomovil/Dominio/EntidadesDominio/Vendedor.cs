using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    public class Vendedor
    {
        private string nombre;
        private string apellido;
        private int cedula;
        private string cargo;
        private DateTime fechaNacimiento;
        private string correo;
        private string contraseña;
        private int codigo;
        private string concesionario;

        public Vendedor(string nombre, string apellido, int cedula, string cargo, DateTime fechaNacimiento, 
            string concesionario)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula = cedula;
            this.cargo = cargo;
            this.fechaNacimiento = fechaNacimiento;
            this.concesionario = concesionario;
        }

        public Vendedor(string nombre, string apellido, int cedula, string cargo, DateTime fechaNacimiento, 
            string correo, string contraseña, int codigo, string concesionario)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula = cedula;
            this.cargo = cargo;
            this.fechaNacimiento = fechaNacimiento;
            this.correo = correo;
            this.contraseña = contraseña;
            this.codigo = codigo;
            this.concesionario = concesionario;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Cedula { get => cedula; set => cedula = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public int Codigo { get => codigo; set => codigo = value; }
        public string Concesionario { get => concesionario; set => concesionario = value; }
    }
}
