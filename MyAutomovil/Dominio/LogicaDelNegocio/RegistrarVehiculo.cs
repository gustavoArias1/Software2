using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.LogicaDelNegocio
{
    class RegistrarVehiculo
    {
        List<Vehiculo> vehiculos = null;

        public void AdicionarVehiculo(string marca,string modelo,string año,string color,string numeroChasis,string placa,string concesionario)
        {
            
        }
        public void ActualizarVehiculo(string marca, string modelo, string año, string color, string numeroChasis, string placa, string concesionario)
        {

        }
        /*
         * Contenido del parametro filtros
         * [0]-> nombreConcesionario
         * [1]-> nombreMarca
         * [2]->precioMin
         * [3]->precioMax
         @ context: RegistrarVehiculo::ConsultarVehiculo 
          
             */
        public List<Vehiculo> ConsultarVehiculo(List<string>filtros)
        {
            //Lista que enviaremos despues de la recoleccion de la información
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            //Obtenemos nuestro Object Concesionario
            Concesionario c = RecuperarConcesionario(filtros[0]);
            //Obtenemos y llenamos nuestra lista de vehiculos en la clase concesionario
            c.vehiculos = c.RecuperarVehiculos();
            //convertimos a las variables precioMin y precioMax 
            int precioMin = Convert.ToInt32(filtros[2]);
            int precioMax = Convert.ToInt32(filtros[3]);
            //realizamos el primer filtro que consiste en que toda la lista de filtros difiere del valor ""
            if(filtros[1] != "" && filtros[2] != "" && filtros[3] != "" /*faltan todos los demas*/){
                foreach ( Vehiculo v in c.vehiculos){
                    if(filtros[1] == v.Marca && v.precio >= precioMin && v.precio <= precioMax)
                    {
                        vehiculos.add(v);
                    }
                }
            }else if(filtros[1] == ""  && filtros[2] != "" && filtros[3] != "" /*faltan todos los demas*/){
                 foreach ( Vehiculo v in c.vehiculos){
                    if(v.precio >= precioMin && v.precio <= precioMax)
                    {
                        vehiculos.add(v);
                    }
                }
            }

            return lista;
        }
        public void ConsultarVehiculo(string placa)
        {
            

        }
        public void EliminarVehiculo(string placa)
        {

        }

        public List<Vehiculo> RecuperarVehiculos(){
            List<Vehiculo> aux = new List<Vehiculo>();

            return aux;
        }

        public Concesionario RecuperarConcesionario(string nombreConcesionario){
            Concesionario c = null;

            return c;
        }


    }


}
