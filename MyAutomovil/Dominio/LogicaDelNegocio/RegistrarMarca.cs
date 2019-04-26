using Dominio.EntidadesDominio;
using System;
using System.Collections.Generic;
using System.Text;
using Persistencia;

namespace Dominio.LogicaDelNegocio
{
    /*
     * La clase registrar marca hara operaciones dml sobre las marcas del sistema realizando verificaciones de datos
     * @ Manuel Galvis
     * @ version 2.0 04/04/2019
     */
    public class RegistrarMarca:ConexionBaseDatos
    {
        public List<Marca> marcas = new List<Marca>();

        public RegistrarMarca()
        {
            Conectar();
        }


        //public ConexionBaseDatos CB = new ConexionBaseDatos();

        /*
         * El metodo AdicionarMarca agrega una nueva marca en la base de datos consultando si dicha marca no existe.
         * @ Manuel Galvis
         * @ version 2.0 04/04/2019
         context RegistrarMarca :: AdicionarMarca
         pre: !ConsultarMarca(nombreMarca) and nombreMarca != null and pais != null
         post: ConsultarMarca(nombreMarca) or self@pre.ConsultarMarca(nombreMarca) or self@!nombreMarca.Exception or self@!pais.Exception
         */
        public  Boolean AdicionarMarca(string nombreMarca,string pais)
        {
            marcas.Clear();
            ConsultarMarca();
            Boolean Existe = false;
            Boolean RegistroMarca = false;
            Marca marca = new Marca { nombreMarca = nombreMarca, pais = pais };
            for (int i = 0; i < marcas.Count; i++)
            {
                if (marcas[i].nombreMarca.Equals(nombreMarca))
                {
                    Existe = true;
                    Console.WriteLine("Marca Existente");
                }

            }
            if (!Existe)
            {
                AdicionarMarcaRepositorio(marca.nombreMarca, marca.pais);
                RegistroMarca = true;
                Console.WriteLine("Se adiciono la Marca");


            }
            else
            {
                RegistroMarca = false;
                Console.WriteLine("Excepcion marca existente");

            }
            return RegistroMarca;
        }

        /*
         * El metodo EliminarMarca elimina una marca especifica de la base de datos.
         * @ Manuel Galvis
         * @ version 2.0 04/04/2019
         context RegistrarMarca :: EliminarMarca
         pre: ConsultarMarca(nombreMarca)
         post: !ConsultarMarca(nombreMarca) or self@pre.ConsultarMarca(nombreMarca)
         */
        public Boolean EliminarMarca(string nombreMarca)
        {
            Boolean Eliminado = false;
            Marca marca = ConsultarMarca(nombreMarca);
            
            if (marcas.Contains(marca))
            {
                for (int i = 0; i < marcas.Count; i++)
                {
                    if (marcas[i].nombreMarca.Equals(marca.nombreMarca))
                    {
                        Eliminado = true;
                        EliminarMarcaRepositorio(nombreMarca);
                    }

                }
            }
            else
            {
                Eliminado = false;
                Console.WriteLine("La marca no existe");

            }
            return Eliminado;
        }

        /*
         * El metodo ActualizarMarca actualizara los datos de una marca especifica modificando sus atributos
         * @ Manuel Galvis
         * @ version 2.0 04/04/2019
         context RegistrarMarca :: ActualizarMarca
         pre: ConsultarMarca(nombreMarca) and nombreMarca != null and pais != null
         post: ConsultarMarca(nombreMarca) or self@!nombreMarca.Exception or self@!pais.Exception
         */
        public Boolean ActualizarMarca(string nombreMarca, string pais)
        {
            Boolean Actualizado = false;
            marcas.Clear();
            ConsultarMarca();
            Marca marca = new Marca { nombreMarca = nombreMarca, pais = "" };
            for (int i = 0; i < marcas.Count; i++)
            {
                if (marcas[i].nombreMarca.Equals(nombreMarca))
                {
                    Actualizado = true;
                    marca.pais = pais;
                }
            }
            if (marca.pais == "")
            {
                Actualizado = false;
                Console.WriteLine("La marca no exite");
            }
            else
            {
                Actualizado = true;
                ActualizarMarcaRepositorio(nombreMarca, pais);
            }
            return Actualizado;
        }

        /*
         * El metodo ConsultarMarca consulta una marca especifica de la base de datos en caso de que no exista mostrara un mensaje de error
         * @ Manuel Galvis
         * @ version 2.0
         context RegistrarMarca :: ConsultarMarca
         pre: nombre != null
         post: ConsultarMarca(nombre) or self@!nombre.Exception
         */
        public Marca ConsultarMarca(string nombre)
        {
            marcas.Clear();
            ConsultarMarca();
            Marca marca = null;
            try
            {
                for (int i = 0; i < marcas.Count; i++)
                {
                    if (marcas[i].nombreMarca.Equals(nombre))
                    {
                        marca = marcas[i];
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (marca == null)
            {
                Console.WriteLine("La marca no existe");
            }
            return marca;
        }

        /*
         * El metodo de consultar marcas llenara la lista de marcas con las marcas almacenadas en la base de datos.
         * @ Manuel Galvis
         * @ version 2.0 04/04/2019
         context RegistrarMarca :: ConsultarMarca
         post: ConsultarMarca()*/
        public void ConsultarMarca()
        {
           
            string Nombre = "";
            string Pais = "";
            List<string[]> lista =ConsultarMarcasRepositorio();

            for (int i = 0; i < lista.Count; i++)
            {
                Nombre = (string)lista[i].GetValue(0);
                Pais = (string)lista[i].GetValue(1);
                marcas.Add(new Marca { nombreMarca = Nombre, pais = Pais });
            }
        }
    }
}