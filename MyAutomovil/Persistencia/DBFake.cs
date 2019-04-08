using System;
using System.Collections.Generic;


namespace Persistencia
{
    public class DBFake
    {
        List<string[]> concesionario;
        List<string[]> marcas;
        List<string[]> vehiculos;
        public DBFake()
        {
            this.concesionario = new List<string[]>();
            this.marcas = new List<string[]>();
            this.vehiculos = new List<string[]>();
            this.Llenar();
        }
            
        public void Llenar()
        {
            concesionario.Add(new string[] { "1", "casautos", "gustavo andres", "calle 10 # 34-09", "43234234", "manizales" });
            concesionario.Add(new string[] { "2", "sadasadsasdd", "sasdasdasd", "sasdasdasd", "sasdasdasd", "sasdasdasd" });
            concesionario.Add(new string[] { "3", "sadasasdasdasdasdd", "sasdasdasd", "sasdasdasd", "sasdasdasd", "sasdasdasd" });
            marcas.Add(new string[] { "Mazda", "Japon" });
            marcas.Add(new string[] { "Nissan", "Japon" });
            marcas.Add(new string[] { "Toyota", "Japon" });
            vehiculos.Add(new string[] {"HEX56","Mazda","Speak3","2012","hdvb6wtd6g63","negro", "casautos", "10839566" });
            vehiculos.Add(new string[] { "HYU76", "Mazda", "Speak3", "2013", "hts7n8ahd6g3", "blanco", "casautos", "10837066" });
            vehiculos.Add(new string[] { "PLX58", "Mazda", "Razer", "2015", "hdvb8j0d6g63", "negro", "casautos", "12839966" });
        }

        public void AdicionarVehiculoRepositorio(string placa,string nombreMarca,string nombreModelo,string año,
            string chasis,string color, double precio ) {
            vehiculos.Add(new string[] { placa,nombreMarca,nombreModelo,año,chasis,color,precio.ToString()});
        }

        public void EliminarVehiculoRepositorio(string placa) {
            for (int i = 0; i < vehiculos.Count; i++) {
                if (vehiculos[i].GetValue(0).Equals(placa)) {
                    vehiculos.RemoveAt(i);
                }
            }
        }

        public void ActualizarVehiculosRepositorio(string placa, string nombreMarca, string nombreModelo, string año,
            string chasis, string color, double precio) {
            for (int i = 0; i < vehiculos.Count; i++)
            {
                if (vehiculos[i].GetValue(0).Equals(placa))
                {
                    vehiculos[i].SetValue(nombreMarca, 1);
                    vehiculos[i].SetValue(nombreModelo, 2);
                    vehiculos[i].SetValue(año, 3);
                    vehiculos[i].SetValue(chasis, 4);
                    vehiculos[i].SetValue(color, 5);
                    vehiculos[i].SetValue(precio.ToString(),6);
                }
            }
        }

        /*
         retorna los datos para crear un concesionario tras el envio de un nombreconcesionario
             */
        public string[] RecuperarConcesionarioRepositorio(string nombreConcesionario) {
            for (int i = 0; i < concesionario.Count; i++) {
                Console.WriteLine(concesionario[i][1]+" "+ nombreConcesionario);
                if (concesionario[i][1].Equals(nombreConcesionario)) {
                    return concesionario[i];
                }
            }
            return null;
        }

        /*
         Recuperar todos los vehiculos que han sido creados
             */
        public List<string[]> RecuperarVehiculosRepositorio() {
            return vehiculos;
        }

        public List<string[]> RecuperarVehiculosRepositorio(string nombreConcesionario) {
            List<string[]> x = new List<string[]>();
            for (int i = 0; i < vehiculos.Count; i++)
            {
                if (vehiculos[i][6].Equals(nombreConcesionario)) {
                    x.Add(vehiculos[i]);
                }
            }
            return x;
        }

        

        public void AdicionarConcesionarioRepositorio(int codigo, string nombreConcesionario, string adminConcesionario, string direccion, string telefono, string cuidad)
        {
            concesionario.Add(new string[] { codigo.ToString(), nombreConcesionario, adminConcesionario, direccion, telefono, cuidad });
        }

        public List<string[]> ConsultarConcesionariosRepositorio()
        {
           
            return concesionario;
        }

        /*
         * Metodo para consultar marcas de la base de datos fake que retornara todos las marcas
         * @ Manuel Galvis
         * @ version 1.0 04/04/2019
         */
        public List<string[]> ConsultarMarcasRepositorio()
        {
            
            return marcas;
        }

        /*
         * Metodo para adicionar marca en la base de datos fake
         * @ Manuel Galvis
         * @ version 1.0 04/04/2019
         */
        public void AdicionarMarcaRepositorio(string nombreMarca, string pais)
        {
            marcas.Add(new string[] { nombreMarca, pais });
        }

        /*
         * Metodo para eliminar un elemento de la base de datos fake
         * @ Manuel Galvis
         * @ version 1.0 04/04/2019
         */
        public void EliminarMarcaRepositorio(string nombreMarca)
        {
            for (int i = 0; i < marcas.Count; i++)
            {
                if (marcas[i].GetValue(0).Equals(nombreMarca))
                {
                    marcas.RemoveAt(i);
                }
            }
        }

        /*
         * Metodo para actualizar un elemento de la base de datos fake
         * @ Manuel Galvis
         * @ version 1.0 04/04/2019
         */
        public void ActualizarMarcaRepositorio(string nombreMarca, string pais)
        {
            for (int i = 0; i < marcas.Count; i++)
            {
                if (marcas[i].GetValue(0).Equals(nombreMarca))
                {
                    marcas[i].SetValue(nombreMarca, 0);
                    marcas[i].SetValue(pais, 1);
                }
            }
        }
    }
}
