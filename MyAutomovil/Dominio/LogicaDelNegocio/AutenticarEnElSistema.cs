using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesDominio;

namespace Dominio.LogicaDelNegocio
{
    class AutenticarEnElSistema
    {
        /**/
        public void AutenticarUsuario (string usuario, string contraseña)
        {
            Usuario us = RecuperarUsuario(usuario);
            if (us != null)
            {
                if (contraseña.Equals(us.Contraseña))
                {
                    /*
                    Enviamos la pag principal    
                 */
                }
                else
                {
                    //Excepcion contraseña erronea
                }
            }
            else {
                //usuario no existe
            }
        }

        public Usuario RecuperarUsuario(string usuario) {
            Usuario u = null;
            /*
             consultamos por el usuario
             devuelvo datos de un usuario y lo creamos
             */
            return u;
        }

        /**/
        public void RecuperarContraseña(string correo)
        {
            Usuario us = RecuperarUsuario(correo);
            if (us == null)
            {
                //Excepcion no existe el correo
            }
            else {
                /*
                 Enviar correo electronico

                Enviar interfaz Autenticar Usuario
                 */
            }
        }


    }
}