using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPNivel3
{
    public static class Validacion
    {
        public static bool validaTextVacio(object control)
        {
            if (control is TextBox texto)
            {
                if (string.IsNullOrEmpty(texto.Text))
                    return true;
                else
                    return false;
            }
            return true;
            
          
        }
    }
}