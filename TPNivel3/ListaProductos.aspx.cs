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
    public partial class ListaProductos : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Security.isAdmin(Session["usuario"]))
            {
                Session.Add("error","Se requieren credenciales de admin");
                Response.Redirect("Error.aspx", false);
            }


            FiltroAvanzado = checkFiltroAvanzado.Checked;

            if (!IsPostBack)
            {
            FiltroAvanzado= false;
            ArticuloNegocio articuloNegocio= new ArticuloNegocio();
            Session.Add("listaArticulos", articuloNegocio.listar());
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.DataBind();

            }

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvArticulos.SelectedDataKey.Value.ToString();

            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        
        {
            dgvArticulos.DataSource = Session["listaArticulos"];
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(filtro.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }

        protected void checkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
             FiltroAvanzado = checkFiltroAvanzado.Checked;
            filtro.Enabled  = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if(ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");

            } else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                dgvArticulos.DataSource = articuloNegocio.filtrar(ddlCampo.SelectedItem.ToString()
                    ,ddlCriterio.SelectedItem.ToString(), 
                    txtFiltroAvanzado.Text);
            dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error",ex);
                throw;
            }
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
              
                
                dgvArticulos.DataSource = Session["listaArticulos"];
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", Security.ManejoDeError(ex));
                Response.Redirect("Error.aspx");
            }
        }
    }
}