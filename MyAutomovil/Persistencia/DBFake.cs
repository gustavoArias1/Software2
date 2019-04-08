using System;
using System.Collections.Generic;

namespace Persistencia
{
    public class DBFake
    {
        List<string[]> concesionario;
        List<string[]> marcas;
        List<string[]> vehiculos;
        List<string[]> reclamos;
        List<string[]> reclamosSolucionados;
        List<String[]> modelos;
        List<string[]> clientes;
        List<string[]> vendedores;

        public DBFake()
        {
            this.concesionario = new List<string[]>();
            this.marcas = new List<string[]>();
            this.vehiculos = new List<string[]>();
            this.reclamos = new List<string[]>();
            this.reclamosSolucionados = new List<string[]>();
            this.clientes = new List<string[]>();
            this.vendedores = new List<string[]>();
            
            this.modelos = new List<string[]>();
            this.Llenar();
        }

        public void Llenar()
        {
            concesionario.Add(new string[] { "1", "casautos", "gustavo andres", "calle 10 # 34-09", "43234234", "manizales" });
            concesionario.Add(new string[] { "2", "sadasadsasdd", "sasdasdasd", "sasdasdasd", "sasdasdasd", "sasdasdasd" });
            concesionario.Add(new string[] { "3", "sadasasdasdasdasdd", "sasdasdasd", "sasdasdasd", "sasdasdasd", "sasdasdasd" });
            marcas.Add(new string[] { "Mazda", "Japon" });
            marcas.Add(new string[] { "Nissan", "Japon" });
            marcas.Add(new string[] { "Toyota", "Japon" });
            vehiculos.Add(new string[] { "HEX56", "Mazda", "Speak3", "2012", "hdvb6wtd6g63", "negro", "casautos", "10839566" });
            vehiculos.Add(new string[] { "HYU76", "Mazda", "Speak3", "2013", "hts7n8ahd6g3", "blanco", "casautos", "10837066" });
            vehiculos.Add(new string[] { "PLX58", "Mazda", "Razer", "2015", "hdvb8j0d6g63", "negro", "casautos", "12839966" });
            reclamos.Add(new string[] { "1", "Vehiculo", "CasaAutos", "Vehiculo con fallas en las puertas", "1059813898" });
            reclamos.Add(new string[] { "2", "TransaccionBancaria", "CasaAutos", "Pago retrasado", "1059813898" });
            reclamos.Add(new string[] { "3", "Vehiculo", "CasaAutos", "Motor averiado", "1059813898" });
            clientes.Add(new string[] { "1", "Javier", "cuathemoc", "5/2/1992", "156278729", "Javihou@gmail.com", "gs8yshns" });
            clientes.Add(new string[] { "2", "Jose", "Rios", "5/4/1990", "15625878729", "HosRe@gmail.com", "gs8a6yhuns" });
            clientes.Add(new string[] { "3", "Pedro", "Cramona", "15/2/1982", "158778729", "PedCaru@gmail.com", "absdhns" });
            vendedores.Add(new string[] {"Juan","Raigoza","61287392","vendedor","4/5/1990","Juan.2@myautomovil.com","6wy8hdyh8",
            "2","casautos"});
            vendedores.Add(new string[] {"pedro","Reyes","61287392","vendedor","4/5/1990","pedro.3@myautomovil.com","6wy8hdyh8",
            "3","casautos"});
            vendedores.Add(new string[] {"admin","casautos","61285672","administrador","8/5/1988","admin.casautos@myautomovil.com","6wy875678u8",
            "1","casautos"});
            modelos.Add(new string[] { "Mazda", "speed", "4", "1600", "Automatica" });
            modelos.Add(new string[] { "Audi", "A4", "4", "2000", "Automatica" });
            modelos.Add(new string[] { "Mazda", "X5", "3", "1800", "Manual" });
        }

        public void AdicionarVehiculoRepositorio(string placa, string nombreMarca, string nombreModelo, string año,
            string chasis, string color, double precio) {
            Console.WriteLine("oshe");
            vehiculos.Add(new string[] { placa, nombreMarca, nombreModelo, año, chasis, color, precio.ToString() });
            Console.WriteLine("tamaño: " + vehiculos.Count);
        }

        public void EliminarVehiculoRepositorio(string placa) {
            for (int i = 0; i < vehiculos.Count; i++) {
                if (vehiculos[i].GetValue(0).Equals(placa)) {
                    vehiculos.RemoveAt(i);
                }
            }
        }

        public void ActualizarVehiculosRepositorio(string placa, string nombreMarca, string nombreModelo, string año,
            string chasis, string color, double precio) {
            for (int i = 0; i < vehiculos.Count; i++)
            {
                if (vehiculos[i].GetValue(0).Equals(placa))
                {
                    vehiculos[i].SetValue(nombreMarca, 1);
                    vehiculos[i].SetValue(nombreModelo, 2);
                    vehiculos[i].SetValue(año, 3);
                    vehiculos[i].SetValue(chasis, 4);
                    vehiculos[i].SetValue(color, 5);
                    vehiculos[i].SetValue(precio.ToString(), 6);
                }
            }
        }

        /*
         retorna los datos para crear un concesionario tras el envio de un nombreconcesionario
             */
        public string[] RecuperarConcesionarioRepositorio(string nombreConcesionario) {
            for (int i = 0; i < concesionario.Count; i++) {
                if (concesionario[i][1].Equals(nombreConcesionario)) {
                    return concesionario[i];
                }
            }
            return null;
        }

        /*
         Recuperar todos los vehiculos que han sido creados
             */
        public List<string[]> RecuperarVehiculosRepositorio() {
            return vehiculos;
        }

        public List<string[]> RecuperarVehiculosRepositorio(string nombreConcesionario) {
            List<string[]> x = new List<string[]>();
            for (int i = 0; i < vehiculos.Count; i++)
            {
                if (vehiculos[i][6].Equals(nombreConcesionario)) {
                    x.Add(vehiculos[i]);
                }
            }
            return x;
        }



        public void AdicionarConcesionarioRepositorio(int codigo, string nombreConcesionario, string adminConcesionario, string direccion, string telefono, string cuidad)
        {
            concesionario.Add(new string[] { codigo.ToString(), nombreConcesionario, adminConcesionario, direccion, telefono, cuidad });
        }

        public void ActualizarConcesionarioRepositorio(string codigo, string nombreConcesionario, string adminConcesionario, string direccion, string telefono, string cuidad)
        {
            for (int i = 0; i < concesionario.Count; i++)
            {
                if (concesionario[i].GetValue(0).Equals(codigo))
                {
                    concesionario[i].SetValue(nombreConcesionario, 1);
                    concesionario[i].SetValue(adminConcesionario, 2);
                    concesionario[i].SetValue(direccion, 3);
                    concesionario[i].SetValue(telefono, 4);
                    concesionario[i].SetValue(cuidad, 5);
                }
            }
        }
        public void EliminarConcesionarioRepositorio(string nombreConcesionario)
        {
            for (int i = 0; i < concesionario.Count; i++)
            {
                if (concesionario[i].GetValue(1).Equals(nombreConcesionario))
                {
                    concesionario.RemoveAt(i);
                }
            }
        }

        public List<string[]> ConsultarConcesionariosRepositorio()
        {

            return concesionario;
        }

        public List<string[]> RecuperarClientesRepositorio() {
            return clientes;
        }

        public void EliminarClienteRepositorio(int codigo) {
            for (int i = 0; i < this.clientes.Count; i++) {
                if (Int32.Parse(this.clientes[i][0]) == codigo) {
                    this.clientes.RemoveAt(i);
                }
            }
        }

        public void ActualizarClienteRepositorio(int codigo, string nombre, string apellido, DateTime fechaNac, int cedula
            , string correo, string contraseña) {
            for (int i = 0; i < this.clientes.Count; i++)
            {
                if (Int32.Parse(this.clientes[i][0]) == codigo)
                {
                    this.clientes[i][1] = nombre;
                    this.clientes[i][2] = apellido;
                    this.clientes[i][3] = fechaNac.Date.ToString("d");
                    this.clientes[i][4] = cedula.ToString();
                    this.clientes[i][5] = correo;
                    this.clientes[i][6] = contraseña;
                }
            }
        }

        public void AdicionarClienteRepositorio(string nombre, string apellido, DateTime fechaNac, int cedula,
            string correo, string contraseña) {
            int c = this.clientes.Count + 1;
            this.clientes.Add(new string[] {c.ToString(),nombre,apellido,fechaNac.Date.ToString("d"),cedula.ToString()
            ,correo,contraseña});
        }

        public void AdicionarEmpleadoRepositorio(string nombre, string apellido, DateTime fechaNac, int cedula, string cargo,
            string concesionario) {
            int id = vendedores.Count + 1;
            this.vendedores.Add(new string[] { nombre,apellido,cedula.ToString(),cargo,fechaNac.Date.ToString("d"),
            "nombre"+"."+id+"@myautomovil.com","sv7yshj8im",id.ToString(),concesionario});
        }

        public void EliminarEmpleadoRepositorio(int codigo) {
            for (int i = 0; i < this.vendedores.Count; i++) {
                if (Int32.Parse(this.vendedores[i][7]) == codigo) {
                    this.vendedores.RemoveAt(i);
                }
            }
        }

        public void ActualizarEmpleadoRepositorio(int codigo, string nombre, string apellido, DateTime fechaNac,
            int cedula, string cargo, string correo, string contraseña, string concesionario)
        {
            for (int i = 0; i < this.vendedores.Count; i++)
            {
                if (Int32.Parse(this.vendedores[i][7]) == codigo)
                {
                    this.vendedores[i][0] = nombre;
                    this.vendedores[i][1] = apellido;
                    this.vendedores[i][2] = cedula.ToString();
                    this.vendedores[i][3] = cargo;
                    this.vendedores[i][4] = fechaNac.Date.ToString("d");
                    this.vendedores[i][5] = correo;
                    this.vendedores[i][6] = contraseña;
                    this.vendedores[i][8] = concesionario;
                }
            }
        }

        public List<string[]> RecuperarEmpleadosRepositorio() {
            return this.vendedores;
        }

        public List<string[]> RecuperarEmpleadosRepositorio(string nombreConcesionario) {
            List<string[]> aux = new List<string[]>();
            for (int i = 0; i < this.vendedores.Count; i++)
            {
                if (Int32.Parse(this.vendedores[i][8]).Equals(nombreConcesionario))
                {
                    aux.Add(this.vendedores[i]);
                }
            }
            return aux;
        }


        /*
         * Metodo para consultar marcas de la base de datos fake que retornara todos las marcas
         * @ Manuel Galvis
         * @ version 1.0 04/04/2019
         */
        public List<string[]> ConsultarMarcasRepositorio()
        {
            
            return marcas;
        }

        /*
         * Metodo para adicionar marca en la base de datos fake
         * @ Manuel Galvis
         * @ version 1.0 04/04/2019
         */
        public void AdicionarMarcaRepositorio(string nombreMarca, string pais)
        {
            marcas.Add(new string[] { nombreMarca, pais });
        }

        /*
         * Metodo para eliminar un elemento de la base de datos fake
         * @ Manuel Galvis
         * @ version 1.0 04/04/2019
         */
        public void EliminarMarcaRepositorio(string nombreMarca)
        {
            for (int i = 0; i < marcas.Count; i++)
            {
                if (marcas[i].GetValue(0).Equals(nombreMarca))
                {
                    marcas.RemoveAt(i);
                }
            }
        }

        /*
         * Metodo para actualizar un elemento de la base de datos fake
         * @ Manuel Galvis
         * @ version 1.0 04/04/2019
         */
        public void ActualizarMarcaRepositorio(string nombreMarca, string pais)
        {
            for (int i = 0; i < marcas.Count; i++)
            {
                if (marcas[i].GetValue(0).Equals(nombreMarca))
                {
                    marcas[i].SetValue(nombreMarca, 0);
                    marcas[i].SetValue(pais, 1);
                }
            }
        }

        /*
         * Metodo para agregar un elemento de reclamo a la base de datos fake
         * @ Manuel Galvis
         * @ version 1.0 07/04/2019
         */
        public void AdicionarReclamoRepositorio(int idReclamo, String tipoReclamo, string concesionario, string descripcion, int idCliente)
        {
            reclamos.Add(new string[] { Convert.ToString(idReclamo), tipoReclamo, concesionario, descripcion, Convert.ToString(idCliente) });
        }

        /*
         * Metodo para consultar reclamos de la base de datos fake que retornara todos los reclamos
         * @ Manuel Galvis
         * @ version 1.0 07/04/2019
         */
        public List<string[]> ConsultarReclamosRepositorio()
        {

            return reclamos;
        }

        /*
         * Metodo para consultar reclamos solucionados de la base de datos fake que retornara todos los reclamos solucionados
         * @ Manuel Galvis
         * @ version 1.0 07/04/2019
         */
        public List<string[]> ConsultarSolucionRepositorio()
        {
            return reclamosSolucionados;
        }

        /*
         * Metodo para agregar un elemento de reclamo solucionado a la base de datos fake
         * @ Manuel Galvis
         * @ version 1.0 07/04/2019
         */
        public void AdicionarReclamoSolucionRepositorio(int idReclamo, string tipoReclamo, string concesionario, string descripcion, int idCliente, string solucionReclamo, int idAdministrador)
        {
            reclamosSolucionados.Add(new string[] { Convert.ToString(idReclamo), tipoReclamo, concesionario, descripcion, Convert.ToString(idCliente), solucionReclamo, Convert.ToString(idAdministrador) });
        }


        public void AdicionarModelosRepositorio(string nombreModelo, string nombreMarca, int numeroPuertas, string cilindraje,
           string transmision)
        {
            modelos.Add(new string[] { nombreModelo, nombreMarca, Convert.ToString (numeroPuertas), cilindraje, transmision });
        }

        public void ActualizarModelosRepositorio(string nombreModelo, string nombreMarca, int numeroPuertas, string cilindraje,
           string transmision)
        {
            for (int i = 0; i < modelos.Count; i++)
            {
                if (modelos[i].GetValue(0).Equals(nombreModelo) && modelos[i].GetValue(0).Equals(nombreMarca))
                {
                    modelos[i].SetValue(nombreMarca, 1);
                    modelos[i].SetValue(nombreModelo, 2);
                    modelos[i].SetValue(numeroPuertas, 3);
                    modelos[i].SetValue(cilindraje, 4);
                    modelos[i].SetValue(transmision, 5);
                   
                }
            }
        }

        public void EliminarModeloRepositorio(string nombreModelo)
        {
            for (int i = 0; i < modelos.Count; i++)
            {
                if (modelos[i].GetValue(0).Equals(nombreModelo))
                {
                    modelos.RemoveAt(i);
                }
            }
        }

        public List<string[]> ConsultarModelosRepositorio()
        {

            return modelos;
        }

        /*
         Recuperar todos los modelos que han sido creados 
             */
        public List<string[]> RecuperarModelosRepositorio()
        {
            return modelos;
        }


    

    }
}
