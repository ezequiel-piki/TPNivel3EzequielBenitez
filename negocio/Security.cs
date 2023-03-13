using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public static class Security
    {
        public static bool isAdmin(object user)
        {
            Usuario usuario;

            if(user != null)
            {
                usuario = (Usuario)user;
            }
            else
            {
                usuario = null;
            }

            if (usuario != null) 
            {
                return usuario.Admin;
             }
            else { return false; }
        }
        public static bool isLogin(object user)
        {
            Usuario usuario;

            if (user != null)
            {

                usuario = (Usuario)user;
            }
            else
            {
                usuario = null;
            }

            // Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
            if (usuario != null && usuario.Id != 0)
            {
                return true;
            } else {  return false; }
        }

        public static string ManejoDeError(Exception ex)
        {

            return ex.ToString();
        }
    }
}
