using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.LogicaDelNegocio
{
    public class MainDePruebas
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("holaaaa");
            RegistrarConcesionario r = new RegistrarConcesionario();
            r.RecuperarConcesionarios();
            System.Console.WriteLine(r.Concesionarios[0].Administrador);
            RegistrarMarca marca = new RegistrarMarca();
            marca.AdicionarMarca("Toyota", "Japon");
            marca.ConsultarMarca();
            for (int i = 0; i < marca.marcas.Count; i++)
            {
                System.Console.WriteLine(marca.marcas[i].Nombre + " " + marca.marcas[i].Pais);
            }
        }
    }
}