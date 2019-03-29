using System;
using System.Collections.Generic;
using Dominio.EntidadesDominio;

namespace Persistencia
{
    public class DBFake
    {
        
        public List<Marca> AgregarMarcas()
        {
            List<Marca> listaMarcas = new List<Marca>();
            Marca m1 = new Marca("audi", "alemania");
            Marca m2 = new Marca("ford", "Colombia");
            Marca m3 = new Marca("mazda", "japon");
            listaMarcas.Add(m1);
            listaMarcas.Add(m2);
            listaMarcas.Add(m3);
            return listaMarcas;
        }

    }
}
