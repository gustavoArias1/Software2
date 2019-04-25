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
            DateTime date = DateTime.Now;
            RegistrarVehiculo r = new RegistrarVehiculo();

            r.ActualizarVehiculo("Commodo LLC", "cx5", "24-02-20", "Blanco", "12500", "abc123", "Audi", 200000);




        }
    }
}