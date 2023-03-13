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
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         txt_Id.Enabled= false;
         txt_Codigo.Enabled= false;
         txt_Nombre.Enabled= false;
         txt_Descripcion.Enabled= false;
         txt_ImagenUrl.Enabled= false;
         txtPrecio.Enabled= false;
         ddl_Categoria.Enabled= false;
         ddl_Marca.Enabled= false;
            
            try
            {
                //configuración de la pantalla
                if (!IsPostBack)
                {
                    //configuracion de cargar DropDownList

                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    MarcaNegocio marcaNegocio = new MarcaNegocio();

                    List<Categoria> listadoCategorias = categoriaNegocio.listar();
                    List<Marca> listadoMarcas = marcaNegocio.listar();

                    ddl_Categoria.DataSource = listadoCategorias;
                    ddl_Categoria.DataValueField = "Id";
                    ddl_Categoria.DataTextField = "Descripcion";
                    ddl_Categoria.DataBind();

                    ddl_Marca.DataSource = listadoMarcas;
                    ddl_Marca.DataValueField = "Id";
                    ddl_Marca.DataTextField = "Descripcion";
                    ddl_Marca.DataBind();

                }

                //configuración si estamos modificando
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    //List<Articulo> listaArticulos = articuloNegocio.listar(id);
                    // Articulo articuloSeleccionado = listaArticulos[0];
                    Articulo articuloSeleccionado = (articuloNegocio.listar(id))[0];


                    //pre cargar todos los campos
                    txt_Id.Text = id;
                    txt_Nombre.Text = articuloSeleccionado.Nombre;
                    txt_Descripcion.Text = articuloSeleccionado.Descripcion;
                    txt_Codigo.Text = articuloSeleccionado.Codigo;
                    txt_ImagenUrl.Text = articuloSeleccionado.ImagenUrl;
                    txtPrecio.Text = articuloSeleccionado.Precio.ToString();

                    //pre cargar desplegables
                    ddl_Categoria.SelectedValue = articuloSeleccionado.Categoria.Id.ToString();
                    ddl_Marca.SelectedValue = articuloSeleccionado.Marca.Id.ToString();

                    txt_ImagenUrl_TextChanged(sender, e);
                }
            
            }
            catch (Exception ex)
            {
                Session.Add("error", Security.ManejoDeError(ex));

                Response.Redirect("Error.aspx");
            }

        }
        protected void txt_ImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgProducto.ImageUrl = txt_ImagenUrl.Text;
        }
    }
}