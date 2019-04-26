using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fachada
{
    public class AdicionarClienteViewModel
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fechaDeNacimiento { get; set; }
        public int cedula { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public string contraseña2 { get; set; }
    }
}
