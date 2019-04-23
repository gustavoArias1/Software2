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
            Conexion.ConnectionString = "server = localhost;  database= MiAutomovil; uid=root; pwd=negro123;";
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
            catch(Exception ex)
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
            
            string query = "delete from marca where nombre='"+nombre+"'";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();
            
        }
        public void ActualizarMarcaRepositorio(string Nombre,string Pais)
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
            {
                Conexion.Open();
            }
            string query = "update table marca set Nombre='" + Nombre + "',Pais='"+Pais+"' where Nombre='"+Nombre+"'";
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
                Pais= Convert.ToString(reader["Pais"]);
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
            string query = "INSERT INTO Marca (Nombre,Pais) VALUES('"+NombreMarca+"','"+Pais+"')";
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
            string query = "INSERT INTO cliente ( Nombre, Apellido,  FechaDeNacimiento, Cedula, Correo, Contraseña) VALUES('" + Nombre + "','" + Apellido + "','" + FechaDeNacimiento + "','" + Cedula + "','" + Correo + "','" + Contraseña + "')";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
            Conexion.Close();

        }

        public List<string[]> RecuperarClientesRepositorio()
        {
            return null;
        }





    }
}
