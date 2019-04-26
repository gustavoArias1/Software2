using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Persistencia
{
    public class ConexionBaseDatos
    {
        private MySqlConnection Conexion = new MySqlConnection();
        public void Conectar()
        {
            Conexion.ConnectionString = "server = localhost;  database= MiAutomovil; uid=root; pwd=manuel24.;";
            try
            {
                Conexion.Open();
                if (Conexion.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("se conecto");


                }
                else
                {
                    Console.WriteLine("llorelo papa");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);


            }
        }





        //............MARCA....................................//
        public void EliminarMarcaRepositorio(string nombre)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }

            string query = "delete from marca where nombre='" + nombre + "'";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();

        }
        public void ActualizarMarcaRepositorio(string Nombre, string Pais)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            string query = "update marca set Pais='" + Pais + "' where Nombre='" + Nombre + "'";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }

        public List<string[]> ConsultarMarcasRepositorio()
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            List<string[]> listaMarcas = new List<string[]>();
            string Pais = "";
            string NombreMarca = "";
            string query = "SELECT * FROM marca";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            MySqlDataReader reader = my.ExecuteReader();

            while (reader.Read())
            {
                NombreMarca = Convert.ToString(reader["Nombre"]);
                Pais = Convert.ToString(reader["Pais"]);
                listaMarcas.Add(new string[] { NombreMarca, Pais });
            }

            Conexion.Close();

            return listaMarcas;
        }

        public void AdicionarMarcaRepositorio(string NombreMarca, string Pais)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            string query = "INSERT INTO Marca (Nombre,Pais) VALUES('" + NombreMarca + "','" + Pais + "')";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }

        //..................CLIENTE..................................................//

        public void AdicionarClienteRepositorio(string Nombre, string Apellido, DateTime FechaDeNacimiento, int Cedula, string Correo, string Contraseña)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            string Fecha = Convert.ToString(FechaDeNacimiento);

            string query = "INSERT INTO cliente ( Nombre, Apellido,  Fecha, Cedula, Correo, Contraseña) VALUES('" + Nombre + "','" + Apellido + "','" + FechaDeNacimiento + "','" + Cedula + "','" + Correo + "','" + Contraseña + "')";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();

        }


        public List<string[]> RecuperarClientesRepositorio()
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            List<string[]> listaClientes = new List<string[]>();
            String Codigo = "";
            string Nombre = "";
            string Apellido = "";
            string Fecha = "";
            string Cedula = "";
            string Correo = "";
            string Contraseña = "";
            string query = "SELECT * FROM cliente";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            MySqlDataReader reader = my.ExecuteReader();

            while (reader.Read())
            {
                Codigo = Convert.ToString(reader["Codigo"]);
                Nombre = Convert.ToString(reader["Nombre"]);
                Apellido = Convert.ToString(reader["Apellido"]);
                Fecha = Convert.ToString(reader["Fecha"]);
                Cedula = Convert.ToString(reader["Cedula"]);
                Correo = Convert.ToString(reader["Correo"]);
                Contraseña = Convert.ToString(reader["Contraseña"]);
                listaClientes.Add(new string[] { Codigo, Nombre, Apellido, Fecha, Cedula, Correo, Contraseña });

            }

            Conexion.Close();
            return listaClientes;
        }

        public void EliminarClienteRepositorio(int Codigo)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }

            string query = "Delete from cliente where Codigo='" + Codigo + "'";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }

        public void ActualizarClienteRepositorio(int codigo, string Nombre, string Apellido, DateTime FechaDeNacimiento, int Cedula, string Correo, string Contraseña)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }

            string Fecha = Convert.ToString(FechaDeNacimiento);
            string query = "update cliente set Nombre='" + Nombre + "',Apellido='" + Apellido + "' ,Fecha='" + Fecha + "',Cedula='" + Cedula + "',Correo='" + Correo + "',Contraseña='" + Contraseña + "'where Codigo='" + codigo + "'";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }



        //..............................Concesionarios..............................................//

        public List<string[]> ConsultarConcesionariosRepositorio()
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            List<string[]> listaConcesionarios = new List<string[]>();
            string Codigo;
            string NombreConcesionario = "";
            string CodigoAdministrador = "";
            string Direccion = "";
            string Telefono = "";
            string Ciudad = "";
            string query = "SELECT * FROM concesionario";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            MySqlDataReader reader = my.ExecuteReader();

            while (reader.Read())
            {
                Codigo = Convert.ToString(reader["Codigo"]);
                NombreConcesionario = Convert.ToString(reader["NombreConcesionario"]);
                CodigoAdministrador = Convert.ToString(reader["CodigoAdministrador"]);
                Direccion = Convert.ToString(reader["Direccion"]);
                Telefono = Convert.ToString(reader["Telefono"]);
                Ciudad = Convert.ToString(reader["Ciudad"]);
                listaConcesionarios.Add(new string[] { Codigo, NombreConcesionario, CodigoAdministrador, Direccion, Telefono, Ciudad });

            }

            Conexion.Close();
            return listaConcesionarios;
        }

        public void AdicionarConcesionarioRepositorio(string NombreConcesionario, int CodigoAdministrador, string Direccion, string Telefono, string Ciudad)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            string query = "INSERT INTO concesionario (NombreConcesionario,CodigoAdministrador,Direccion,Telefono,Ciudad) VALUES('" + NombreConcesionario + "','" + CodigoAdministrador + "','" + Direccion + "','" + Telefono + "','" + Ciudad + "')";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EliminarConcesionarioRepositorio(string NombreConcesionario)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }

            string query = "Delete from concesionario where NombreConcesionario='" + NombreConcesionario + "'";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }

        public void ActualizarConcesionarioRepositorio(string Codigo, string NombreConcesionario, int CodigoAdministrador, string Direccion, string Telefono, string Ciudad)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }

            string query = "update concesionario set NombreConcesionario='" + NombreConcesionario + "',CodigoAdministrador='" + CodigoAdministrador + "' ,Direccion='" + Direccion + "',Telefono='" + Telefono + "',Ciudad='" + Ciudad + "'where Codigo='" + Codigo + "'";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }

        public string[] RecuperarConcesionarioRepositorio(string Nombre)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }

            string query = "SELECT * FROM concesionario where NombreConcesionario='" + Nombre + "'";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            MySqlDataReader reader = my.ExecuteReader();
            string[] Concesionario = new string[6];

            while (reader.Read())
            {
                string Codigo = Convert.ToString(reader["Codigo"]);
                string NombreConcesionario = Convert.ToString(reader["NombreConcesionario"]);
                string CodigoAdministrador = Convert.ToString(reader["CodigoAdministrador"]);
                string Direccion = Convert.ToString(reader["Direccion"]);
                string Telefono = Convert.ToString(reader["Telefono"]);
                string Ciudad = Convert.ToString(reader["Ciudad"]);
                Concesionario = new string[] { Codigo, NombreConcesionario, CodigoAdministrador, Direccion, Telefono, Ciudad };


            }

            Conexion.Close();
            return Concesionario;



        }

        //..................................Crud empleado................................................//

        public List<string[]> RecuperarEmpleadosRepositorio()
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            List<string[]> listaEmpleados = new List<string[]>();
            string Codigo = "";
            string Nombre = "";
            string Apellido = "";
            string Fecha = "";
            string Cargo = "";
            string Cedula = "";
            string Correo = "";
            string Contraseña = "";
            string Concesionario = "";
            string query = "SELECT * FROM vendedores";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            MySqlDataReader reader = my.ExecuteReader();

            while (reader.Read())
            {

                Codigo = Convert.ToString(reader["Codigo"]);
                Nombre = Convert.ToString(reader["Nombre"]);
                Apellido = Convert.ToString(reader["Apellido"]);

                Cedula = Convert.ToString(reader["Cedula"]);
                if (Cedula.Length > 10)
                {
                    Cedula = Cedula.Substring(0, 9);
                }
                Cargo = Convert.ToString(reader["Cargo"]);
                Fecha = Convert.ToString(reader["FechaNacimiento"]);
                Correo = Convert.ToString(reader["Correo"]);
                Contraseña = Convert.ToString(reader["Contraseña"]);
                Concesionario = Convert.ToString(reader["Concesionario"]);

                listaEmpleados.Add(new string[] { Nombre, Apellido, Cedula, Cargo, Fecha, Correo, Contraseña, Codigo, Concesionario });

            }

            Conexion.Close();
            return listaEmpleados;
        }

        public void ActualizarEmpleadoRepositorio(int Codigo, string Nombre, string Apellido, DateTime FechaNacimiento, int Cedula, string Cargo, string Correo, string Contraseña, string Concesionario)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }

            string Fecha = Convert.ToString(FechaNacimiento);
            string query = "update vendedores set Nombre='" + Nombre + "',Apellido='" + Apellido + "' ,FechaNacimiento='" + Fecha + "',Cargo='" + Cargo + "',Cedula='" + Cedula + "',Correo='" + Correo + "',Contraseña='" + Contraseña + "',Concesionario='" + Concesionario + "'where Codigo='" + Codigo + "'";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }

        public void EliminarEmpleadoRepositorio(int Codigo)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }

            string query = "delete from vendedores where Codigo='" + Codigo + "'";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }

        public void AdicionarEmpleadoRepositorio(string Nombre, string Apellido, DateTime FechaNacimiento, int Cedula, string Cargo, string NombreConcesionario)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }

            string Fecha = Convert.ToString(FechaNacimiento);
            string query = "Insert Into vendedores (Nombre,Apellido,Cedula,Cargo,FechaNacimiento,Correo,Contraseña,Concesionario) values ('" + Nombre + "','" + Apellido + "','" + Cedula + "','" + Cargo + "','" + Fecha + "','correo@falta','contraseñafalta','" + NombreConcesionario + "')";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }



        public List<string[]> RecuperarEmpleadosRepositorio(string NombreConcesionario)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            List<string[]> listaEmpleados = new List<string[]>();
            string Codigo = "";
            string Nombre = "";
            string Apellido = "";
            string Fecha = "";
            string Cargo = "";
            string Cedula = "";
            string Correo = "";
            string Contraseña = "";
            string Concesionario = "";
            string query = "SELECT * FROM vendedores where concesionario='" + NombreConcesionario + "'";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            MySqlDataReader reader = my.ExecuteReader();

            while (reader.Read())
            {

                Codigo = Convert.ToString(reader["Codigo"]);
                Nombre = Convert.ToString(reader["Nombre"]);
                Apellido = Convert.ToString(reader["Apellido"]);

                Cedula = Convert.ToString(reader["Cedula"]);
                if (Cedula.Length > 10)
                {
                    Cedula = Cedula.Substring(0, 9);
                }
                Cargo = Convert.ToString(reader["Cargo"]);
                Fecha = Convert.ToString(reader["FechaNacimiento"]);
                Correo = Convert.ToString(reader["Correo"]);
                Contraseña = Convert.ToString(reader["Contraseña"]);
                Concesionario = Convert.ToString(reader["Concesionario"]);

                listaEmpleados.Add(new string[] { Nombre, Apellido, Cedula, Cargo, Fecha, Correo, Contraseña, Codigo, Concesionario });

            }

            Conexion.Close();
            return listaEmpleados;
        }

        //..............................CrudModelo...............................................//

        public List<string[]> ConsultarModelosRepositorio()
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            List<string[]> listaModelos = new List<string[]>();
            string NombreModelo = "";
            string NombreMarca = "";
            string NumeroPuertas = "";
            string Cilindraje = "";
            string Transmision = "";

            string query = "SELECT * FROM modelo";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            MySqlDataReader reader = my.ExecuteReader();

            while (reader.Read())
            {
                NombreModelo = Convert.ToString(reader["NombreModelo"]);
                NombreMarca = Convert.ToString(reader["NombreMarca"]);
                NumeroPuertas = Convert.ToString(reader["NumeroPuertas"]);
                Cilindraje = Convert.ToString(reader["NumeroPuertas"]);
                Transmision = Convert.ToString(reader["NumeroPuertas"]);

                listaModelos.Add(new string[] { NombreModelo, NombreMarca, NumeroPuertas, Cilindraje, Transmision });
            }

            Conexion.Close();

            return listaModelos;
        }

        public void EliminarModeloRepositorio(string NombreModelo)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }

            string query = "delete from modelo where NombreModelo='" + NombreModelo + "'";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }

        public void ActualizarModelosRepositorio(string NombreModelo, string nombreMarca, int NumeroPuertas, string Cilindraje, string Transmision)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }

            string query = "update modelo set NumeroPuertas='" + NumeroPuertas + "',Cilindraje='" + Cilindraje + "' ,Transmision='" + Transmision + "'where NombreModelo='" + NombreModelo + "'";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }

        public void AdicionarModelosRepositorio(string NombreModelo, string NombreMarca, int NumeroPuertas, string Cilindraje, string Transmision)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }

            string query = "INSERT INTO modelo (NombreModelo,NombreMarca,Transmision,NumeroPuertas,Cilindraje) values('" + NombreModelo + "','" + NombreMarca + "','" + Transmision + "','" + NumeroPuertas + "','" + Cilindraje + "')";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }

        //..................................CRUD RECLAMO..................................................//

        public List<string[]> ConsultarReclamosRepositorio()
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            List<string[]> listaReclamos = new List<string[]>();
            string TipoReclano = "";
            string Concesionario = "";
            string Descripcion = "";
            string SolucionReclamo = "";
            string IdReclamo = "";
            string IdCliente = "";
            string IdAdministrador = "";


            string query = "SELECT * FROM reclamo";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            MySqlDataReader reader = my.ExecuteReader();

            while (reader.Read())
            {
                TipoReclano = Convert.ToString(reader["TipoReclamo"]);
                Concesionario = Convert.ToString(reader["Concesionario"]);
                Descripcion = Convert.ToString(reader["Descripcion"]);
                SolucionReclamo = Convert.ToString(reader["SolucionReclamo"]);
                IdReclamo = Convert.ToString(reader["IdReclamo"]);
                IdCliente = Convert.ToString(reader["IdCliente"]);
                IdAdministrador = Convert.ToString(reader["IdAdministrador"]);




                listaReclamos.Add(new string[] { IdReclamo, TipoReclano, Concesionario, Descripcion, IdCliente });
            }

            Conexion.Close();

            return listaReclamos;
        }

        public List<string[]> ConsultarSolucionRepositorio(string concesionario)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            List<string[]> listaReclamos = new List<string[]>();
            string TipoReclano = "";
            string Concesionario = "";
            string Descripcion = "";
            string SolucionReclamo = "";
            string IdReclamo = "";
            string IdCliente = "";
            string IdAdministrador = "";


            string query = "SELECT * FROM reclamo where Concesionario='" + concesionario + "'";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            MySqlDataReader reader = my.ExecuteReader();

            while (reader.Read())
            {
                TipoReclano = Convert.ToString(reader["TipoReclamo"]);
                Concesionario = Convert.ToString(reader["Concesionario"]);
                Descripcion = Convert.ToString(reader["Descripcion"]);
                SolucionReclamo = Convert.ToString(reader["SolucionReclamo"]);
                IdReclamo = Convert.ToString(reader["IdReclamo"]);
                IdCliente = Convert.ToString(reader["IdCliente"]);
                IdAdministrador = Convert.ToString(reader["IdAdministrador"]);




                listaReclamos.Add(new string[] { IdReclamo, TipoReclano, Concesionario, Descripcion, IdCliente, SolucionReclamo, IdAdministrador });
            }

            Conexion.Close();

            return listaReclamos;
        }


        public int ConsultarAdministrador(string Concesionario)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            int CodigoAdministrador = 0;
            string query = "select CodigoAdministrador from concesionario where NombreConcesionario='" + Concesionario + "'";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            MySqlDataReader reader = my.ExecuteReader();

            while (reader.Read())
            {
                CodigoAdministrador = Convert.ToInt32(reader["CodigoAdministrador"]);
            }

            Conexion.Close();
            return CodigoAdministrador;
        }

        public void AdicionarReclamoRepositorio(int IdReclamo, string TipoReclamo, string Concesionario, string Descripcion, int IdCliente)
        {
            int CodigoAdministrador = ConsultarAdministrador(Concesionario);
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }


            string query = "INSERT INTO reclamo (TipoReclamo,Concesionario,Descripcion,SolucionReclamo,Idcliente,IdAdministrador) values('" + TipoReclamo + "','" + Concesionario + "','" + Descripcion + "','----------','" + IdCliente + "','" + CodigoAdministrador + "')";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }

        public void AdicionarReclamoSolucionRepositorio(int IdReclamo, string TipoReclamo, string Concesionario, string Descripcion, int IdCliente, string solucionReclamo, int idAministrador)
        {
            int CodigoAdministrador = ConsultarAdministrador(Concesionario);
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }


            string query = "INSERT INTO reclamo (TipoReclamo,Concesionario,Descripcion,SolucionReclamo,Idcliente,IdAdministrador) values('" + TipoReclamo + "','" + Concesionario + "','" + Descripcion + "','" + solucionReclamo + "','" + IdCliente + "','" + CodigoAdministrador + "')";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }


        //...................................Autenticar..............................................................//

        public List<string[]> ConsultarUsuariosRepositorio()
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            List<string[]> listaUsuarios = new List<string[]>();
            string Usuario = "";
            string Contraseña = "";
            string Tipo = "";
            string query = "SELECT * FROM usuarios";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            MySqlDataReader reader = my.ExecuteReader();

            while (reader.Read())
            {
                Usuario = Convert.ToString(reader["User"]);
                Contraseña = Convert.ToString(reader["Contraseña"]);
                Tipo = Convert.ToString(reader["Tipo"]);

                listaUsuarios.Add(new string[] { Usuario, Contraseña, Tipo });
            }

            Conexion.Close();

            return listaUsuarios;
        }

        public void ActualizarUsuario(string usuario,string contraseña)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }

            string query = "update usuarios set contraseña='" + contraseña + "'where User='" + usuario + "'";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }

        //..................................Vehiculos.....................................................//


        public List<string[]> RecuperarVehiculosRepositorio()
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            List<string[]> listaVehiculos = new List<string[]>();
            string Placa = "";
            string Marca = "";
            string Modelo = "";
            string Año = "";
            string Numerochasis = "";
            string Color = "";
            string Concesionario = "";
            string Precio = "";



            string query = "SELECT * FROM vehiculos ";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            MySqlDataReader reader = my.ExecuteReader();

            while (reader.Read())
            {
                Placa = Convert.ToString(reader["Placa"]);
                Marca = Convert.ToString(reader["Marca"]);
                Modelo = Convert.ToString(reader["Modelo"]);
                Año = Convert.ToString(reader["Año"]);
                Numerochasis = Convert.ToString(reader["NumeroChasis"]);
                Color = Convert.ToString(reader["Color"]);
                Concesionario = Convert.ToString(reader["Concesionario"]);
                Precio = Convert.ToString(reader["Precio"]);





                listaVehiculos.Add(new string[] { Placa, Marca, Modelo, Año, Numerochasis, Color, Concesionario,Precio });
            }

            Conexion.Close();

            return listaVehiculos;
        }

        public void EliminarVehiculoRepositorio(string Placa)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }

            string query = "delete from vehiculos where Placa='" + Placa + "'";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }

        public void ActualizarVehiculosRepositorio(string placa, string marca, string modelo, string año, string numeroChasis, string color,string Concesionario, double precio)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }

            string Precio2 = Convert.ToString(precio);
            string query = "update vehiculos set Marca='" + marca + "', Modelo='" + modelo + "' ,Año='" + año + "',NumeroChasis='" + numeroChasis + "',Color='" + color + "',Concesionario='" + Concesionario + "',Precio='"+Precio2+"' where Placa='" + placa + "' ";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }

        public void AdicionarVehiculoRepositorio(string placa, string marca, string modelo, string año, string numeroChasis, string color,string concesionario, double precio)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }

            string Precio2 = Convert.ToString(precio);
            string query = "INSERT INTO vehiculos (Placa,Marca,Modelo,Año,NumeroChasis,Color,Concesionario,Precio) values('" + placa + "','" + marca + "','" + modelo + "','" + año + "','" + numeroChasis + "','" + color + "','" + concesionario + "','" + Precio2 + "')";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
        }



        public List<string[]> RecuperarVehiculosRepositorio(string nombreConcesionario)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            List<string[]> listaVehiculos = new List<string[]>();
            string Placa = "";
            string Marca = "";
            string Modelo = "";
            string Año = "";
            string Numerochasis = "";
            string Color = "";
            string Concesionario = "";
            string Precio = "";



            string query = "SELECT * FROM vehiculos where Concesionario='"+nombreConcesionario+"' ";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            MySqlDataReader reader = my.ExecuteReader();

            while (reader.Read())
            {
                Placa = Convert.ToString(reader["Placa"]);
                Marca = Convert.ToString(reader["Marca"]);
                Modelo = Convert.ToString(reader["Modelo"]);
                Año = Convert.ToString(reader["Año"]);
                Numerochasis = Convert.ToString(reader["NumeroChasis"]);
                Color = Convert.ToString(reader["Color"]);
                Concesionario = Convert.ToString(reader["Concesionario"]);
                Precio = Convert.ToString(reader["Precio"]);





                listaVehiculos.Add(new string[] { Placa, Marca, Modelo, Año, Numerochasis, Color, Concesionario, Precio });
            }

            Conexion.Close();

            return listaVehiculos;
        }

        //...................................CompraUsado................................................//


        public List<string[]> RecuperarComprasRepositorio(string nombreConcesionario)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            List<string[]> listaCompras = new List<string[]>();
            string fechaCompra="";
            string precioCompra = "";
            string placa = "";
            string codigoProveedor;


            string query = "SELECT * FROM compras where Concesionario='" + nombreConcesionario + "' ";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            MySqlDataReader reader = my.ExecuteReader();

            while (reader.Read())
            {
                fechaCompra = Convert.ToString(reader["FechaCompra"]);
                precioCompra = Convert.ToString(reader["PrecioCompra"]);
                placa = Convert.ToString(reader["Placa"]);
                codigoProveedor = Convert.ToString(reader["CodigoProveedor"]);
          
                listaCompras.Add(new string[] { nombreConcesionario, fechaCompra, precioCompra, placa, codigoProveedor });
            }

            Conexion.Close();

            return listaCompras;
        }

        public void AdicionarCompraRepositorio(string nombreConcesionario, DateTime fechaCompra, double precioCompra, string placa, int codigoProveedor)
        {

        }

    }
}
