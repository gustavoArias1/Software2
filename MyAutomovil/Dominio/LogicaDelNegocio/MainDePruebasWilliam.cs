using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesDominio;

namespace Dominio.LogicaDelNegocio
{
    class MainDePruebasWilliam
    {
        public static void Main(string[] args) {
            /*AQUI EMPIEZAN LAS PRUEBAS DE REGISTRAR VEHICULOS*/
            RegistrarVehiculo v = new RegistrarVehiculo();
            List<Vehiculo> va = v.ConsultarVehiculo(new List<string> { "casautos", "", "425", "452638738", "", "", "" });
            for (int i = 0; i < va.Count; i++)
            {
                Console.WriteLine(va[i].Placa + " " + va[i].Marca + " " + va[i].Modelo + " " + va[i].Precio);
            }
            v.AdicionarVehiculo("PLX78", "Mazda", "Razer", "2015", "hdvb8j0d6g63", "negro", "casautos", 12939989);
            
        }
    }

}
