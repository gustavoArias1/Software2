using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesDominio;

namespace Dominio.LogicaDelNegocio
{
    public class MainDePruebas
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("holaaaa");
            //RegistrarConcesionario r = new RegistrarConcesionario();
            //r.RecuperarConcesionarios();
            //System.Console.WriteLine(r.Concesionarios[0].Administrador);

            /*AQUI EMPIEZAN LAS PRUEBAS DE MARCAS*/
            //RegistrarMarca marca = new RegistrarMarca();
            //marca.ConsultarMarca();
            //marca.AdicionarMarca("Toyota", "Japon");
            //marca.EliminarMarca("Toyota");
            //marca.ActualizarMarca("Toyota", "Colombia");
            /*for (int i = 0; i < marca.marcas.Count; i++)
            {
                Console.WriteLine(marca.marcas[i].Nombre + " " +marca.marcas[i].Pais);
            }*/

            /*AQUI EMPIEZAN LAS PRUEBAS DE REGISTRAR VEHICULOS*/
            RegistrarVehiculo v = new RegistrarVehiculo();
            List<Vehiculo> va = v.ConsultarVehiculo(new List<string> { "casautos", "", "425", "452638738", "", "", "" });
            for (int i = 0; i < va.Count; i++) {
                Console.WriteLine(va[i].Placa + " " + va[i].Marca + " " + va[i].Modelo + " " + va[i].Precio);
            }
        }
    }
}