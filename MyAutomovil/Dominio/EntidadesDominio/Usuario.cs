using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    class Usuario
    {
        private string user;
        private string contraseña;
        private string tipo;

        public Usuario(string usuario, string contraseña, string tipo)
        {
            this.user = usuario;
            this.contraseña = contraseña;
            this.tipo = tipo;
        }

        public string User { get => user; set => user = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}
