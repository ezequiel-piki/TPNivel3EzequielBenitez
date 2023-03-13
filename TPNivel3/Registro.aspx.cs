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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Security.isLogin(Session["usuario"]))

                    Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("error", Security.ManejoDeError(ex));
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                //Page.Validate();
                //if (!Page.IsValid)
                //    return;

                Usuario usuario= new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();
                usuario.Email = txtEmail.Text;
                usuario.Pass  = txtPassword.Text;
                usuario.Id = usuarioNegocio.registrarUsuario(usuario);

                Session.Add("usuario",usuario);

                emailService.armarCorreo(usuario.Email, "Bienvenid@","Hola bienvenido");
                emailService.enviarMail();
                Response.Redirect("Default.aspx",false);
            }
            catch (Exception ex)
            {

                Session.Add("error", Security.ManejoDeError(ex));
            }
        }
    }
}