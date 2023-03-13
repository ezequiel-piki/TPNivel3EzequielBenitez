
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPNivel3
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgNavbar.ImageUrl = "https://assets.stickpng.com/images/585e4beacb11b227491c3399.png";
           
            if ((Usuario)Session["usuario"] != null)
            {
                imgNavbar.ImageUrl = "~/Imagenes/" + ((Usuario)Session["usuario"]).ImagenUrl;
                labelUsuario.Text = ((Usuario)Session["usuario"]).Email.ToString();

            }

            if (!(Page is Login || Page is Default || Page is Registro || Page is Error)) 
            {
             if (!Security.isLogin(Session["usuario"]))
                Response.Redirect("Login.aspx", false);
            else 
            {
                Usuario usuario = (Usuario)Session["usuario"];
                labelUsuario.Text = usuario.Email;
                if (!string.IsNullOrEmpty(usuario.ImagenUrl))
                {
                    imgNavbar.ImageUrl = "~/Imagenes/" + ((Usuario)Session["usuario"]).ImagenUrl;
                }
            }
            }


        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx",false);
        }

       

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}