using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    class Administrador
    {
        private int codigo;
        private string nombre;
        private string apellido;
        private int cedula;
        private string cargo;
        private DateTime fechaNacimiento;
        private string correo;
        private string contraseña;
        private Concesionario concesionario;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Cedula { get => cedula; set => cedula = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        internal Concesionario Concesionario { get => concesionario; set => concesionario = value; }

        public Administrador(string nombre, string apellido, int cedula, string cargo, DateTime fechaNacimiento, 
            string correo, string contraseña)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula = cedula;
            this.cargo = cargo;
            this.fechaNacimiento = fechaNacimiento;
            this.correo = correo;
            this.contraseña = contraseña;
            this.codigo = 0;
            this.concesionario = BuscarConcesionario(concesionario.NombreConcesionario);
        }

        public Administrador(string nombre, string apellido, int cedula, string cargo, DateTime fechaNacimiento,
            string correo, string contraseña,int codigo,Concesionario concesionario)
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


        private Concesionario BuscarConcesionario(string nombreconcesionario) {
            Concesionario c = null;
            
            /*
            aqui viene la extraccion de la DB del concesionario

            c = new Concesionario();
             */ 
            return null;
        }

        private int buscarCodigo(int cedula, string nombre) {
            int codigo = 0;
            /*
             Traemos el codigo de la base de datos
             */
            return codigo;
        }
    }
}
