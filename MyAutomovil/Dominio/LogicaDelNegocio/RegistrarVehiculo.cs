using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Text;
using Persistencia;

namespace Dominio.LogicaDelNegocio
{
    public class RegistrarVehiculo : ConexionBaseDatos
    {
        List<Vehiculo> vehiculos = null;

        public RegistrarVehiculo()
        {
            Conectar();
        }


        /*
     * @William vasquez
       @ version 1.0 05/04/2019
         Adicionar un vehiculo 
         context: RegistrarVehiculo::AdicionarVehiculo(marca:string,modelo:string,año:string,color:string,numeroChasis:string
         placa:string,concesionario:string,precio:double)
         post: vehiculos.Count() = vehiculos.count() + 1
         */
        public void AdicionarVehiculo(string marca,string modelo,string año,string color,string numeroChasis,string placa,string concesionario,double precio)
        {
            AdicionarVehiculoRepositorio(placa, marca, modelo, año, numeroChasis, color,concesionario, precio);
        }
        /*
        * @William vasquez
          @ version 1.0 05/04/2019
            Actualizar un vehiculo
            context: RegistrarVehiculo::ActualizarVehiculo(marca:string,modelo:string,año:string,color:string,numeroChasis:string
            placa:string,concesionario:string,precio:double)
            pre: ConsultarVehiculo(filtros:List):vehiculos.count() > 0
            post: Vehiculo2 != vehiculo1 
            */
        public void ActualizarVehiculo(string marca, string modelo, string año, string color, string numeroChasis, string placa, string concesionario,double precio)
        {
            ActualizarVehiculosRepositorio(placa, marca, modelo, año, numeroChasis, color,concesionario, precio);
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
         * 
         * nombremarca|precioMin|precioMax|nombresModelos|Color|año
         *      o           o       o           o           o     o
         *      x           o       o           x           o     o
         *      o           o       o           o           x     o
         *      o           o       o           o           o     x
         *      o           o       o           o           x     x
         *      x           o       o           x           x     o
         *      x           o       o           x           o     x
         *      x           o       o           x           x     x
         *      o           o       o           x           x     o
         *      o           o       o           x           o     o
         *      o           o       o           x           x     x
         *      o           o       o           x           o     x
         *      
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
            Concesionario c;
            c = RecuperarConcesionario(filtros[0]);
            //Obtenemos y llenamos nuestra lista de vehiculos en la clase concesionario
            c.vehiculos = c.RecuperarVehiculos();
            //convertimos a las variables precioMin y precioMax 
                int precioMin = Convert.ToInt32(filtros[2]);
                int precioMax = Convert.ToInt32(filtros[3]);
                //obtenemos la lista de modelos
                string[] modelos = filtros[4].Split(',');
                if (c.vehiculos.Count > 0)
                {
                    //realizamos el primer filtro que consiste en que toda la lista de filtros difiere del valor ""
                    if (filtros[1] != "" && filtros[2] != "" && filtros[3] != "" && filtros[4] != "" && filtros[5] != ""
                        && filtros[6] != "")
                    {
                        foreach (Vehiculo v in c.vehiculos)
                        {
                            if (filtros[1].Equals(v.Marca) && v.Precio >= precioMin && v.Precio <= precioMax && ContieneModelo(modelos, v.Modelo)
                                && v.Color.Equals(filtros[5]) && v.Año.Equals(filtros[6]))
                            {
                                vehiculos.Add(v);
                            }
                        }
                        // filtro cuando no se ingresa una marca, por lo tanto tampoco un modelo pero si los demas
                    }
                    else if (filtros[1] == "" && filtros[2] != "" && filtros[3] != "" && filtros[4] == "" && filtros[5] != ""
                       && filtros[6] != "")
                    {
                        foreach (Vehiculo v in c.vehiculos)
                        {
                            if (v.Precio >= precioMin && v.Precio <= precioMax && v.Color.Equals(filtros[5]) && v.Año.Equals(filtros[6]))
                            {
                                vehiculos.Add(v);
                            }
                        }
                        //Todos menos color 
                    }
                    else if (filtros[1] != "" && filtros[2] != "" && filtros[3] != "" && filtros[4] != "" && filtros[5] == ""
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
                }
                else {
                    //Excepcion no hay vehiculos en este concesionario
                    System.Console.WriteLine("no hay vehiculos en este concesionario");
                }

                if (vehiculos.Count == 0)
                {
                    //lanzarExcepcion de no se encontraron coincidencias
                    System.Console.WriteLine("No se encontraron coincidencias");
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
         * @William vasquez
           @ version 1.2 05/04/2019
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
                //Excepcion no hay vehiculos en este concesionario
                System.Console.WriteLine("no hay vehiculos en este concesionario");
            }
            if (v == null)
            {
                //lanzarExcepcion de no se encontraron coincidencias
                System.Console.WriteLine("No se encontraron coincidencias");
            }
            return v;
        }
        /*
         * @William vasquez
           @ version 1.1 05/04/2019
             Consultar los vehiculos agregados el último mes
             context: RegistrarVehiculo::ConsultarVehiculo(nombreConcesionario :string):vehiculo
             pre: concesionario.vehiculos.count() > 0
             post: return vehiculo:Vehiculo
             */
        public List<Vehiculo> ConsultarVehiculoUltimoMesAgregado(string nombreConcesionario){
            Concesionario c = RecuperarConcesionario(nombreConcesionario);
            if (c.RecuperarVehiculosUltimoMes().Count == 0)
            {
                //lanzarExcepcion de no se encontraron coincidencias
                System.Console.WriteLine("No se encontraron coincidencias");
            }
            return c.RecuperarVehiculosUltimoMes();
        }
        /*
        * @William vasquez
          @ version 1.0 05/04/2019
            Eliminar vehiculo 
            context: RegistrarVehiculo::EliminarVehiculo(placa :string)
            pre: ConsultarVehiculo(filtros:List):vehiculos.count() > 0
            post: vehiculos.Count() = vehiculos.count() - 1
            */
        public void EliminarVehiculo(string placa)
        {
            EliminarVehiculoRepositorio(placa);
        }

        public List<Vehiculo> RecuperarVehiculos(){
            List<Vehiculo> aux = new List<Vehiculo>();
            List<string[]> vehiculosAux = RecuperarVehiculosRepositorio();
            if (vehiculosAux.Count > 0)
            {
                for (int i = 0; i < vehiculosAux.Count; i++)
                {
                    aux.Add(new Vehiculo(vehiculosAux[i][0], vehiculosAux[i][0], vehiculosAux[i][0], vehiculosAux[i][0],
                        vehiculosAux[i][0], vehiculosAux[i][0], vehiculosAux[i][0], Double.Parse(vehiculosAux[i][7])));
                }
            }
            return aux;
        }
        public Concesionario RecuperarConcesionario(string nombreConcesionario){
            Concesionario c;
            string[] aux = RecuperarConcesionarioRepositorio(nombreConcesionario);
            if (aux == null)
            {
                return null;
            }
            else
            {
                c = new Concesionario(Int32.Parse(aux[0]), aux[1], Int32.Parse(aux[2]), aux[3], aux[4], aux[5]);
            }
            return c;
        }


    }


}

