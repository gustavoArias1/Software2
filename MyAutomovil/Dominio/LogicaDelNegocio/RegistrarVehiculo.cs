using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.LogicaDelNegocio
{
    class RegistrarVehiculo
    {
        LinkedList<string> filtros = new LinkedList<string>();

        public void AdicionarVehiculo(string marca,string modelo,string año,string color,string numeroChasis,string placa,string concesionario)
        {
            
        }
        public void ActualizarVehiculo(string marca, string modelo, string año, string color, string numeroChasis, string placa, string concesionario)
        {

        }
        public LinkedList<Vehiculo> ConsultarVehiculo(LinkedList<string>filtros)
        {
            return null;
        }
        public void ConsultarVehiculo(string placa)
        {
        
        }
        public void EliminarVehiculo(string placa)
        {

        }
    }


}
