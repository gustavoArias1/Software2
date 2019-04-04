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

        public List<string[]> ConsultarConcesionariosRepositorio()
        {
            this.Llenar();
            return concesionario;
        }

        /*
         * Metodo para consultar marcas de la base de datos fake que retornara todos las marcas
         * @ Manuel Galvis
         * @ version 1.0 04/04/2019
         */
        public List<string[]> ConsultarMarcasRepositorio()
        {
            this.Llenar();
            return marcas;
        }
    }
}
