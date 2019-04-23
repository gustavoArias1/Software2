using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesDominio;
using Persistencia;


namespace Dominio.LogicaDelNegocio
{
    public class MainDePruebas
    {
        public static void Main(string[] args)
        {
            RegistrarCliente r = new RegistrarCliente();
            DateTime date = DateTime.Now;
            r.AdicionarCliente("Gustavo","Andres",12123123,date,"gus@sdasd","chupelo");

        }
    }
}