using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using Dominio.EntidadesDominio;
using Dominio.LogicaDelNegocio;

namespace Pruebas
{   
    [TestFixture]
    class Program
    {
        static void Main(string[] args)
        {
        }

        [TestCase]
        public void registrarMarcaTest() {

            RegistrarMarca r = new RegistrarMarca();
            Assert.AreEqual(true, r.AdicionarMarca("Mercedez3","A10"));
        }

        
        [TestCase]
        public void EliminarMarcaTest()
        {

            RegistrarMarca E = new RegistrarMarca();
            Assert.AreEqual(true, E.EliminarMarca("Mercedez2"));
        }

        [TestCase]
        public void ActualizarMarcaTest()
        {
            RegistrarMarca A = new RegistrarMarca();
            Assert.AreEqual(true, A.ActualizarMarca("Mate","Zam"));
        }


        [TestCase]
        public void AutenticarSistemaTest()
        {
            AutenticarEnElSistema valida= new AutenticarEnElSistema();
            Assert.AreEqual(false, valida.AutenticarUsuario("vitae.odio@lorem.ca", "NEO57FMB8I"));
        }

        [TestCase]
        public void AdicionarModeloTest()
        {
            RegistrarModelo adicion = new RegistrarModelo ();
            Assert.AreEqual(true, adicion.AdicionarModelo("speed", "Ut Inc.", 4,"1000","mecanica"));
        }


        [TestCase]
        public void ActualizarClientesTest()
        {
            RegistrarCliente A = new RegistrarCliente();
            DateTime data = DateTime.Now;
            Assert.AreEqual(true, A.ActualizarCliente(1,"Uriel", "Mathews",1651061,data,"aaaaaaaaa@gmail.com", " WTC31JUJ2GN"));
        }

        [TestCase]
        public void AdicionarConcesionarioTest()
        {
            RegistrarConcesionario C= new RegistrarConcesionario();
            DateTime data = DateTime.Now;
            Assert.AreEqual(true, C.AdicionarConcesionario("Kia",5,"cll 45 n 65-01","8705555","Manizales"));
        }

    }
}
