using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesDominio;

namespace Dominio.LogicaDelNegocio
{
    /*
   * La clase AutenticarEnElSistema hara operaciones dml sobre las modelos del sistema realizando verificaciones de datos
   * @ Yherson Blandon
   * @ version 3.0 05/04/2019
   */
    class AutenticarEnElSistema
    {
        /*
       * El metodo AutenticarUsuario confirma la existencia en la base de datos consultando si dicho usuario existe.
       * @ Yherson Blandon
       * @ version 3.0 05/04/2019
       context AutenticarUsuario :: RecuperarUsuario
       pre: AutenticarUsuario(usuario, contraseña) and usuario != null and contraseña != null 
       post: AutenticarUsuario(usuario, contraseña) or  self@!usuario.Exception or self@!contraseña.Exception 
       */
        public void AutenticarUsuario (string usuario, string contraseña)
        {
            Usuario us = RecuperarUsuario(usuario);
            if (us != null)
            {
                if (contraseña.Equals(us.Contraseña))
                {
                    Console.WriteLine("usuario recuperado");
                }
                else
                {
                    Console.WriteLine("contraseña incorrecta");
                }
            }
            else {
                Console.WriteLine("usuario no existente");
            }
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
            Usuario us = RecuperarUsuario(correo);
            if (us == null)
            {
                Console.WriteLine("el correo no existe en la base de datos");


            }
            else {
                Console.WriteLine("revise su correo electronico para recuperar la contraseña");
            }
        }


    }
}