using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPNivel3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Security.isLogin(Session["usuario"]))
                
                    Response.Redirect("Default.aspx",false);
                
            }
            catch (Exception ex)
            {

                Session.Add("error", Security.ManejoDeError(ex));
                Response.Redirect("Error.aspx",false);
            }
        }

        protected void btnLoguearse_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuario = new Usuario();
           
            try
            {
                if (Validacion.validaTextVacio(txtEmailLogin) || Validacion.validaTextVacio(txtPasswordLogin))
                {
                    Session.Add("error", "debes completar ambos campos");
                    Response.Redirect("Error.aspx");
                }
                usuario.Email = txtEmailLogin.Text;
                usuario.Pass  = txtPasswordLogin.Text;

               if (usuarioNegocio.Login(usuario))
                {
                    Session.Add("usuario",usuario);
                    Response.Redirect("PerfilUsuario.aspx",false);
                }
               else {
                  
                    Session.Add("error","Algún dato ingresado es incorrecto");
                    Response.Redirect("Error.aspx",false);
                }
              
                

            }
            catch(System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {

                Session.Add("error", Security.ManejoDeError(ex));
                Response.Redirect("Error.aspx");
            }
        }
    }
}