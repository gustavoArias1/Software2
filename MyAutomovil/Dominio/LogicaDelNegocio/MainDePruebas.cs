using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.LogicaDelNegocio
{
    class MainDePruebas
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("holaaaa");
            RegistrarConcesionario r = new RegistrarConcesionario();
            r.RecuperarConcesionarios();
            System.Console.WriteLine(r.Concesionarios[1].Administrador);

        }
    }
}
