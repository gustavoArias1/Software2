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

            /*AQUI EMPIEZAN LAS PRUEBAS DE MARCAS*/
            RegistrarMarca marca = new RegistrarMarca();
            //marca.ConsultarMarca();
            //marca.AdicionarMarca("Toyota", "Japon");
            //marca.EliminarMarca("Toyota");
            //marca.ActualizarMarca("Toyota", "Colombia");
            /*for (int i = 0; i < marca.marcas.Count; i++)
            {
                Console.WriteLine(marca.marcas[i].Nombre + " " +marca.marcas[i].Pais);
            }*/
        }
    }
}