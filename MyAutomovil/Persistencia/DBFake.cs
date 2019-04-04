using System;
using System.Collections.Generic;


namespace Persistencia
{
    public class DBFake
    {
        List<string[]> concesionario;
        List<string[]> marcas;

        public DBFake()
        {
            this.concesionario = new List<string[]>();
            this.marcas = new List<string[]>();
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
                if (marcas[i].Equals(nombreMarca))
                {
                    marcas[i].SetValue(nombreMarca, 0);
                    marcas[i].SetValue(pais, 1);
                }
            }
        }
    }
}
