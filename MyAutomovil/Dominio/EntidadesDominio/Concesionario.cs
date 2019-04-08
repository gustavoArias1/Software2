using System;
using System.Collections.Generic;
using System.Text;
using Persistencia;
namespace Dominio.EntidadesDominio
{
    public class Concesionario :DBFake
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
            List<string[]> vendedoresAux2 = RecuperarEmpleadosRepositorio(this.NombreConcesionario);
            if (vendedoresAux2.Count > 0) {
                for (int i = 0; i < vendedoresAux2.Count; i++) {
                    vendedoresAux.Add(new Vendedor(vendedoresAux2[i][0], vendedoresAux2[i][1], Int32.Parse(vendedoresAux2[i][2]),
                        vendedoresAux2[i][3], DateTime.Parse(vendedoresAux2[i][4]), vendedoresAux2[i][5], vendedoresAux2[i][6],
                        Int32.Parse(vendedoresAux2[i][7]), vendedoresAux2[i][8]));
                }
            }
            else {
                Console.WriteLine("No se encontraron coincidencias para este concesionario");
            }
             
            return vendedoresAux;
        }


        public List<Vehiculo> RecuperarVehiculos()
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            List<string[]> vehiculosAux = RecuperarVehiculosRepositorio(this.nombreConcesionario);
            if (vehiculosAux.Count > 0)
            {
                for (int i = 0; i < vehiculosAux.Count; i++)
                {
                    vehiculos.Add(new Vehiculo(vehiculosAux[i][0], vehiculosAux[i][1], vehiculosAux[i][2], vehiculosAux[i][3],
                        vehiculosAux[i][4], vehiculosAux[i][5], vehiculosAux[i][6], Double.Parse(vehiculosAux[i][7])));
                }
            }
            return vehiculos;
        }

        /*
          context:: Concesionario::RecuperarCompras()
          pre: compras.count() > 0
          post: vehiculos:List
         
          */
        public List<Compra> RecuperarCompras(){
            List<Compra> compras = new List<Compra>();
            return compras;
        }
     
        public List<Vehiculo> RecuperarVehiculosUltimoMes(){
            List<Vehiculo> vehiculosAux = new List<Vehiculo>();
            List<Vehiculo> aux = RecuperarVehiculos();
            List<string> placas = RecuperarPlacasUltimoMes();
            if(aux.Count > 0){
                foreach(Vehiculo v in aux){
                    if(placas.Contains(v.Placa)){
                        vehiculosAux.Add(v);
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
                    if(fechaList[1].Equals(fechaHoy[1])){
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
