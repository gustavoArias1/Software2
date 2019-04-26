using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesDominio;
using Persistencia;

namespace Dominio.LogicaDelNegocio
{
    /*
   * La clase AutenticarEnElSistema hara operaciones dml sobre las modelos del sistema realizando verificaciones de datos
   * @ Yherson Blandon
   * @ version 3.0 05/04/2019
   */
    public class AutenticarEnElSistema:ConexionBaseDatos
    {

        public List<Usuario> Usuarios = new List<Usuario>();

        public AutenticarEnElSistema()
        {

            Conectar();
        }

        /*
       * El metodo AutenticarUsuario confirma la existencia en la base de datos consultando si dicho usuario existe.
       * @ Yherson Blandon
       * @ version 3.0 05/04/2019
       context AutenticarUsuario :: RecuperarUsuario
       pre: AutenticarUsuario(usuario, contraseña) and usuario != null and contraseña != null 
       post: AutenticarUsuario(usuario, contraseña) or  self@!usuario.Exception or self@!contraseña.Exception 
       */
        public Boolean AutenticarUsuario (string Usuario, string Contraseña)
        {
            Usuarios.Clear();
            RecuperarUsuarios();
            Boolean usuarioexiste = false;
            Boolean contraseñaexiste = false;
            Boolean bandera;
            if (Usuario.Length>0 & Contraseña.Length>0)
            {
                for(int i=0; i<Usuarios.Count; i++)
                {
                    if (Usuarios[i].user.Equals(Usuario))
                    {
                        usuarioexiste = true;
                        if (Usuarios[i].contraseña.Equals(Contraseña))
                        {
                            contraseñaexiste = true;
                        }
                       
                    }
                    
                }
                if (usuarioexiste)
                {
                    if (contraseñaexiste)
                    {
                        bandera = true;
                    }
                    else
                    {
                        bandera = false;

                    }
                }
                else
                {
                    bandera = false;

                }
            }
            else
            {
                bandera = false;
            }
            return bandera;
        }

        /*
       * El metodo RecuperarUsuario obtiene la informacion de la base de datos consultando si dicho usuario existe.
       * @ Yherson Blandon
       * @ version 3.0 05/04/2019
       context RecuperarUsuario :: AutenticarUsuario
       pre:  RecuperarUsuario(usuario) and usuario != null 
       post: RecuperarUsuario(usuario) or  self@!usuario.Exception  
       */
        public Usuario RecuperarUsuario(string usuario) {
            Usuario u = null;

            if (u!= null)
            {
                Console.WriteLine("revise su correo electronico para recuperar el usuario");
            }
            
             
            return u;
        }

        /*
       * El metodo RecuperarContraseña obtiene la informacion de la base de datos enviando estos al correo para poder autenticarse.
       * @ Yherson Blandon
       * @ version 3.0 05/04/2019
       context RecuperarContraseña :: RecuperarUsuario
       pre:  RecuperarContraseña(correo) and correo != null 
       post: RecuperarContraseña(correo) or  self@!correo.Exception  
       */
        public void RecuperarContraseña(string correo)
        {
            Usuarios.Clear();
            RecuperarUsuarios();
            Boolean existe = false;
            if (correo.Length > 0)
            {
                for (int i=0; i<Usuarios.Count; i++){
                    if (Usuarios[i].user.Equals(correo))
                    {
                        existe = true;
                    }
                   
                }
                if (existe)
                {
                    Console.WriteLine("REVISE SU CORREO PARA NUEVA CONTRASEÑA");

                }
                else
                {
                    Console.WriteLine("Excepcion usuario inexistente");

                }

            }
            else
            {
                Console.WriteLine("Excepcion Campo vacio");
            }
        }


        public void RecuperarUsuarios()
        {
            string Usuario = "";
            string Contraseña = "";
            string Tipo = "";
            List<string[]> lista = ConsultarUsuariosRepositorio();

            for (int i = 0; i < lista.Count; i++)
            {
                Usuario= (string)lista[i].GetValue(0);
                Contraseña = (string)lista[i].GetValue(1);
                Tipo=(string)lista[i].GetValue(2);
                Usuarios.Add(new Usuario { user = Usuario, contraseña = Contraseña, tipo = Tipo });
            }
        }

    }
}