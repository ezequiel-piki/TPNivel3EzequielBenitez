using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using dominio;
namespace TPNivel3
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo>  ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            ListaArticulos = articuloNegocio.listar();


            if (!IsPostBack)
            {
              repRepeater.DataSource = ListaArticulos;
              repRepeater.DataBind();

            }


        }

        //protected void btnEjemplo_Click(object sender, EventArgs e)
        //{
        //    string valor = ((Button)sender).CommandArgument;
        //}
    }
}