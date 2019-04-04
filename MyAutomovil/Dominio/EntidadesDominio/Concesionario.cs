using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.EntidadesDominio
{
    public class Concesionario
    {
        private int codigo; 
        private string nombreConcesionario;
        private string nombreAdministrador;
        private string direccion;
        private string telefono;
        private string ciudad;
        public List<Vendedor> vendedores = null;
        public List<Vehiculo> vehiculos = null;
        public List<Compra> compras = null; 

        public Concesionario(string nombreConcesionario, string administrador, string direccion, string telefono, string ciudad)
        {
            this.nombreConcesionario = nombreConcesionario;
            this.nombreAdministrador = administrador;
            this.direccion = direccion;
            this.telefono = telefono;
            this.ciudad = ciudad;
        }
        public Concesionario(int codigo, string nombreConcesionario, string administrador, string direccion, string telefono, string ciudad)
        {
            this.nombreConcesionario = nombreConcesionario;
            this.nombreAdministrador = administrador;
            this.direccion = direccion;
            this.telefono = telefono;
            this.ciudad = ciudad;
            this.codigo = codigo;
            this.vendedores = new List<Vendedor>();
        }

        public int Codigo { get => codigo; set => codigo = value; }
        public string NombreConcesionario { get => nombreConcesionario; set => nombreConcesionario = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Administrador { get => nombreAdministrador; set => nombreAdministrador = value; }

        public List<Vendedor> RecuperarEmpleados() {
            List<Vendedor> vendedoresAux = new List<Vendedor>();
            /*
             Consulta DB
             */
            return vendedoresAux;
        }


         public List<Vendedor> RecuperarVehiculos() {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            /*
             Consulta DB
             */
            return vehiculos;
        }

        public List<Compra> RecuperarCompras(){
            List<Compra> compras = new List<Compras>();
            return compras;
        }
        /*
         context:: Concesionario::RecuperarCompras(){
         pre: compras.count() > 0
         post: vehiculos:List
            }
             */
        public List<Vehiculo> RecuperarVehiculosUltimoMes(){
            List<Vehiculo> vehiculosAux = new List<Vehiculo>();
            List<Vehiculo> aux = RecuperarVehiculos();
            List<string> placas = RecuperarPlacasUltimoMes();
            if(aux.Count > 0){
                foreach(Vehiculo v in aux){
                    if(placas.Contains(v.Placa)){
                        vehiculosAux.Add();
                    }
                }
            }else{
                //excepcion no hay vehiculos en este concesionario
            }
            return vehiculosAux;
        }

        private List<string> RecuperarPlacasUltimoMes(){
            List<string> placas = new List<string>();
            //llenamos la lista de compras
            this.compras = RecuperarCompras();
            if(compras.Count >  0 ){
                foreach(Compra c in compras){
                    //fecha de adquisicion de l vehiculo a un proveedor
                    string fecha = c.Fecha.Date.ToString("d");
                    //tomamos el mes
                    string [] fechaList = fecha.Split('/');
                    // tomamos la fecha del dia
                    string fechaHoy = DateTime.Now.Date.ToString("d");
                    //tomamos el mes
                    string [] fechaHoyList = fechaHoy.Split('/');
                    //si los meses son iguales guarde la placa
                    if(fechaList[1] == fechaHoy[1]){
                        placas.Add(c.Placa);
                    }
                }
            }else{
                //Excepcion no hay compras de vehiculos en el concesionario
            }
            return placas;
        }
    }
}
