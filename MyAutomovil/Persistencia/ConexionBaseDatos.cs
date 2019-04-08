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
        public void Insertar()
        {
            string query = "INSERT INTO prueba (id_prueba) VALUES(666)";
            MySqlCommand my = new MySqlCommand(query, Conexion);
            my.ExecuteNonQuery();
        }

       

    }
}
