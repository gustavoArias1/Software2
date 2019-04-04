using System;
using System.Collections.Generic;


namespace Persistencia
{
    public class DBFake
    {
        List<string[]> concesionario;

        public DBFake()
        {
            this.concesionario = new List<string[]>();
        }
            

        public void Llenar()
        {
            
            concesionario.Add(new string[] { "1", "casautos", "gustavo andres", "calle 10 # 34-09", "43234234", "manizales" });
            concesionario.Add(new string[] { "2", "sadasadsasdd", "sasdasdasd", "sasdasdasd", "sasdasdasd", "sasdasdasd" });
            concesionario.Add(new string[] { "3", "sadasasdasdasdasdd", "sasdasdasd", "sasdasdasd", "sasdasdasd", "sasdasdasd" });

            
        }

        public List<string[]> ConsultarConcesionariosRepositorio()
        {
            this.Llenar();
            return concesionario;

        }
        
        

    }
}
