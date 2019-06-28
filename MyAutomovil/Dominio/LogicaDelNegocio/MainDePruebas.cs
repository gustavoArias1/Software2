using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesDominio;
using Persistencia;


namespace Dominio.LogicaDelNegocio
{
    public class MainDePruebas
    {
        public static void Main(string[] args)
        {
            ConexionBaseDatos conexion = new ConexionBaseDatos();
            conexion.Conectar();
            conexion.ActualizarUsuario("ac.eleifend@pede.ca", "HWY72FYY0FR");
            
        }
    }
}