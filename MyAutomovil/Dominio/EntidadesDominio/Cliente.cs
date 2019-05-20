using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    public class Cliente
    {
        //YOLO
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fechaDeNacimiento { get; set; }
        public int cedula { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
    }
}