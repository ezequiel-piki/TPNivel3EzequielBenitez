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
    public partial class FromularioArticulo : System.Web.UI.Page
    {
        public bool ConfirmarEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmarEliminacion = false;
            txt_Id.Enabled= false;
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
                    txtPrecio.Text = articuloSeleccionado.Precio.ToString();
                    txt_ImagenUrl.Text = articuloSeleccionado.ImagenUrl;


                    //pre cargar desplegables
                    ddl_Categoria.SelectedValue = articuloSeleccionado.Categoria.Id.ToString();
                    ddl_Marca.SelectedValue =articuloSeleccionado.Marca.Id.ToString();

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
            imgProducto.ImageUrl= txt_ImagenUrl.Text;
        }

        protected void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                Articulo nuevoArticulo = new Articulo();
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                nuevoArticulo.Codigo = txt_Codigo.Text;
                nuevoArticulo.Nombre = txt_Nombre.Text;
                nuevoArticulo.Descripcion = txt_Descripcion.Text;
                nuevoArticulo.Precio = decimal.Parse(txtPrecio.Text.ToString());
                nuevoArticulo.ImagenUrl = txt_ImagenUrl.Text;
                
                nuevoArticulo.Marca = new Marca();
                nuevoArticulo.Marca.Id = int.Parse(ddl_Marca.SelectedValue);

                nuevoArticulo.Categoria = new Categoria();
                nuevoArticulo.Categoria.Id = int.Parse(ddl_Categoria.SelectedValue);

                if (Request.QueryString["id"] != null )
                {
                    nuevoArticulo.Id = int.Parse(txt_Id.Text);
                    // articuloNegocio.modificarArticuloSP(nuevoArticulo);
                    articuloNegocio.updateArticulo(nuevoArticulo);
                }
                else
                articuloNegocio.addArticulo(nuevoArticulo);

                
               
                
                Response.Redirect("ListaProductos.aspx",false);
            }
            catch (Exception ex)
            {
                Session.Add("error", Security.ManejoDeError(ex));
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkConfirmarEliminación.Checked) { 
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                articuloNegocio.eliminar(int.Parse(txt_Id.Text));
                Response.Redirect("ListaProductos.aspx",false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", Security.ManejoDeError(ex));
                Response.Redirect("Error.aspx");
            }
        }
    }
}