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
                marcas.Add(marca);
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
            //Acceso base de datos enviando nombreMerca, pais con sentencia update;
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
                return null;
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

