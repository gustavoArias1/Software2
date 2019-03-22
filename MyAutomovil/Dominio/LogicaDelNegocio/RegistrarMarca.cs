using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.LogicaDelNegocio
{
    class RegistrarMarca
    {
        List<Marca> marcas = new List<Marca>();
        public void AdicionarMarca(string nombreMarca,string pais)
        {
            //Acceso base de datos metodo recuperar marcas
            Marca marca = new Marca(nombreMarca, pais);
            if (marcas.Contains(marca))
            {
                //Exception
            }
            else
            {
                //Invocar metodo de adicion de marcas en la base de datos.
                //Exception
            }
        }

        public void EliminarMarca(string nombreMarca)
        {
            //Acceso base de datos enviando delete
            //Exception
        }

        public void ActualizarMarca(string nombreMarca, string pais)
        {
            //Acceso base de datos enviando nombreMarca, pais con la sentencia update
        }

        public Marca ConsultarMarca(string nombre)
        {
            //Acceso base de datos metodo recuperar marcas
            Marca marca = null;
            try
            {
                for (int i = 0; i < marcas.Count; i++)
                {
                    if (marcas[i].Nombre.Equals(nombre))
                    {
                        marca = marcas[i];
                    }
                }
            } catch (Exception ex)
            {
                //Exception
            }
            if (marca == null)
            {
                //Exception
            }
            return marca;
        }

        public List<Marca> RecuperarMarcas()
        {
            //Codigo de acceso a la base de datos
            return null;
        }
    }
}

