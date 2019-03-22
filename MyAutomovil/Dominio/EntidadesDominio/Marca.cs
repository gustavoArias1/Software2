using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    class Marca
    {
        private string nombre;
        private string pais;

        public Marca(string nombre, string pais)
        {
            this.nombre = nombre;
            this.pais = pais;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Pais { get => pais; set => pais = value; }
    }
}
