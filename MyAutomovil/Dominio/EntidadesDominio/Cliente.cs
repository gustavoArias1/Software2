using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    public class Cliente
    {
        private string codigo;
        private string nombre;
        private string apellido;
        private DateTime fechaDeNacimiento;
        private int cedula;
        private string correo;
        private string contraseña;

        public Cliente(string nombre, string apellido, DateTime fechaDeNacimiento, int cedula, string correo, 
            string contraseña)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaDeNacimiento = fechaDeNacimiento;
            this.cedula = cedula;
            this.correo = correo;
            this.contraseña = contraseña;
        }

        public Cliente(string codigo, string nombre, string apellido, DateTime fechaDeNacimiento, int cedula, 
            string correo, string contraseña)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaDeNacimiento = fechaDeNacimiento;
            this.cedula = cedula;
            this.correo = correo;
            this.contraseña = contraseña;
        }

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public int Cedula { get => cedula; set => cedula = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
    }
}