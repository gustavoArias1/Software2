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
         * [4]->nombresModelos debe venir con el formato aus33,aujhg89
         * [5]->color
         * [6]->año
         @William vasquez
         @ version 1.5 05/04/2019
         @ context: RegistrarVehiculo::ConsultarVehiculo(filtros:List) 
          pre: concesionario.vehiculos.count() > 0
          post: return vehiculos:List
             */
        public List<Vehiculo> ConsultarVehiculo(List<string> filtros)
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
            //obtenemos la lista de modelos
            string[] modelos = filtros[4].Split(',');
            //realizamos el primer filtro que consiste en que toda la lista de filtros difiere del valor ""
            if (filtros[1] != "" && filtros[2] != "" && filtros[3] != "" && filtros[4] != "" && filtros[5] != ""
                && filtros[6] != "") {
                foreach (Vehiculo v in c.vehiculos) {
                    if (filtros[1].Equals(v.Marca) && v.Precio >= precioMin && v.Precio <= precioMax && ContieneModelo(modelos,v.Modelo)
                        && v.Color.Equals(filtros[5]) && v.Año.Equals(filtros[6]))
                    {
                        vehiculos.Add(v);
                    }
                }
                // filtro cuando no se ingresa una marca, por lo tanto tampoco un modelo pero si los demas
            } else if (filtros[1] == "" && filtros[2] != "" && filtros[3] != "" && filtros[4] == "" && filtros[5] != ""
                 && filtros[6] != "")
            {
                foreach (Vehiculo v in c.vehiculos) {
                    if (v.Precio >= precioMin && v.Precio <= precioMax && v.Color.Equals(filtros[5]) && v.Año.Equals(filtros[6]))
                    {
                        vehiculos.Add(v);
                    }
                }
                //Todos menos color 
            } else if (filtros[1] != "" && filtros[2] != "" && filtros[3] != "" && filtros[4] != "" && filtros[5] == ""
                 && filtros[6] != "")
            {
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (filtros[1].Equals(v.Marca) && v.Precio >= precioMin && v.Precio <= precioMax &&
                        ContieneModelo(modelos, v.Modelo) && v.Año.Equals(filtros[6]))
                    {
                        vehiculos.Add(v);
                    }
                }
            }
            //todos menos año
            else if (filtros[1] != "" && filtros[2] != "" && filtros[3] != "" && filtros[4] != "" && filtros[5] != ""
                && filtros[6] == "")
            {
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (filtros[1].Equals(v.Marca) && v.Precio >= precioMin && v.Precio <= precioMax &&
                        ContieneModelo(modelos, v.Modelo) && v.Color.Equals(filtros[5]))
                    {
                        vehiculos.Add(v);
                    }
                }
            }
            //todos menos año y color
            else if (filtros[1] != "" && filtros[2] != "" && filtros[3] != "" && filtros[4] != "" && filtros[5] == ""
                && filtros[6] == "")
            {
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (filtros[1].Equals(v.Marca) && v.Precio >= precioMin && v.Precio <= precioMax &&
                        ContieneModelo(modelos, v.Modelo))
                    {
                        vehiculos.Add(v);
                    }
                }
            }
            //todo menos color y marca por lo tanto tampoco modelo
            else if (filtros[1] == "" && filtros[2] != "" && filtros[3] != "" && filtros[4] == "" && filtros[5] == ""
                && filtros[6] != "")
            {
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (v.Precio >= precioMin && v.Precio <= precioMax &&
                        v.Año.Equals(filtros[6]))
                    {
                        vehiculos.Add(v);
                    }
                }
            }
            //todo menos marca y año por lo tanto tampoco modelo
            else if (filtros[1] == "" && filtros[2] != "" && filtros[3] != "" && filtros[4] == "" && filtros[5] != ""
                && filtros[6] == "")
            {
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (v.Precio >= precioMin && v.Precio <= precioMax &&
                        v.Color.Equals(filtros[5]))
                    {
                        vehiculos.Add(v);
                    }
                }
            }
            //solo precios
            else if (filtros[1] == "" && filtros[2] != "" && filtros[3] != "" && filtros[4] == "" && filtros[5] == ""
                && filtros[6] == "")
            {
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (v.Precio >= precioMin && v.Precio <= precioMax)
                    {
                        vehiculos.Add(v);
                    }
                }
            }
            //todo menos modelo y color
            else if (filtros[1] != "" && filtros[2] != "" && filtros[3] != "" && filtros[4] == "" && filtros[5] == ""
               && filtros[6] != "")
            {
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (filtros[1].Equals(v.Marca) && v.Precio >= precioMin && v.Precio <= precioMax 
                        && v.Año.Equals(filtros[6]))
                    {
                        vehiculos.Add(v);
                    }
                }
            }
            // todo menos modelo
            else if (filtros[1] != "" && filtros[2] != "" && filtros[3] != "" && filtros[4] == "" && filtros[5] != ""
               && filtros[6] != "")
            {
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (filtros[1].Equals(v.Marca) && v.Precio >= precioMin && v.Precio <= precioMax
                        && v.Año.Equals(filtros[6]) && v.Color.Equals(filtros[5]))
                    {
                        vehiculos.Add(v);
                    }
                }
            }
            //todo menos modleo.color,año
            else if (filtros[1] != "" && filtros[2] != "" && filtros[3] != "" && filtros[4] == "" && filtros[5] == ""
               && filtros[6] == "")
            {
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (filtros[1].Equals(v.Marca) && v.Precio >= precioMin && v.Precio <= precioMax)
                    {
                        vehiculos.Add(v);
                    }
                }
            }
            //todo menos modelo y año
            else if (filtros[1] != "" && filtros[2] != "" && filtros[3] != "" && filtros[4] == "" && filtros[5] != ""
               && filtros[6] == "")
            {
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (filtros[1].Equals(v.Marca) && v.Precio >= precioMin && v.Precio <= precioMax && v.Año.Equals(filtros[6]))
                    {
                        vehiculos.Add(v);
                    }
                }
            }
            return vehiculos;
        }
        /*
         metodo que me retorna si un modelo existe en la lista de modelos filtrados
             */
        private Boolean ContieneModelo(string []modelos,string modelo)
        {
            for (int i = 0; i < modelos.Length; i++) {
                if (modelos[i].Equals(modelo)) {
                    return true;
                }
            }
            return false;
        }
        /*
             Consultar vehiculo solo por el atributo placa
             context: RegistrarVehiculo::ConsultarVehiculo(placa:string,nombreConcesionario :string):vehiculo
             pre: concesionario.vehiculos.count() > 0
             post: return vehiculo:Vehiculo
             */
        public Vehiculo ConsultarVehiculo(string nombreConcesionario,string placa)
        {
            Vehiculo v = null;
            //Obtenemos nuestro Object Concesionario
            Concesionario c = RecuperarConcesionario(nombreConcesionario);
            //Obtenemos y llenamos nuestra lista de vehiculos en la clase concesionario
            c.vehiculos = c.RecuperarVehiculos();
            //verificamos que el concesionario tenga vehiculos
            if(c.vehiculos.Count > 0){
                foreach(Vehiculo aux in c.vehiculos){
                        if(aux.Placa == placa){
                        v = aux;
                    }
                }
            }else{
                //excepcion o error no hay vehiculos para este concesionario
            }
            return v;
        }

        public List<Vehiculo> ConsultarVehiculoUltimoMesAgregado(string nombreConcesionario){
            Concesionario c = RecuperarConcesionario(nombreConcesionario);
            return c.RecuperarVehiculosUltimoMes();
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
