using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listarConSP()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos data = new AccesoDatos();
            try
            {
                //consultar a la DB mediante store procedure
                data.setearProcedimiento("storedListar");


                data.ejecutarLectura();

                while (data.LectorSQL.Read())
                {
                    Articulo articuloAuxiliar = new Articulo();
                    articuloAuxiliar.Id = (int)data.LectorSQL["Id"];
                    articuloAuxiliar.Codigo = (string)data.LectorSQL["Codigo"];
                    articuloAuxiliar.Nombre = (string)data.LectorSQL["Nombre"];
                    articuloAuxiliar.Descripcion = (string)data.LectorSQL["Descripcion"];

                    if (!(data.LectorSQL["ImagenUrl"] is DBNull))
                        articuloAuxiliar.ImagenUrl = (string)data.LectorSQL["ImagenUrl"];

                    if (!(data.LectorSQL["Precio"] is DBNull))
                        articuloAuxiliar.Precio = decimal.Parse(data.LectorSQL["Precio"].ToString());


                    articuloAuxiliar.Marca = new Marca();
                    articuloAuxiliar.Marca.Id = (int)data.LectorSQL["IdMarca"];
                    articuloAuxiliar.Marca.Descripcion = (string)data.LectorSQL["Marca"];
                    articuloAuxiliar.Categoria = new Categoria();
                    articuloAuxiliar.Categoria.Id = (int)data.LectorSQL["IdCategoria"];
                    articuloAuxiliar.Categoria.Descripcion = (string)data.LectorSQL["Categoria"];


                    lista.Add(articuloAuxiliar);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> listar( string id ="")
        {

            List<Articulo> listaArticulos = new List<Articulo>();

            SqlConnection conexionSQL = new SqlConnection();
            SqlCommand comandoSQL = new SqlCommand();
            SqlDataReader lectorSQL;

            try
            {
                conexionSQL.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true";
                comandoSQL.CommandType = System.Data.CommandType.Text;
                comandoSQL.CommandText = "select Codigo, Nombre, Art.Descripcion, ImagenUrl, Marcs.Descripcion AS Marca, Categoris.Descripcion AS Categoria, Precio, Art.IdMarca, Art.IdCategoria, Art.Id from Articulos Art inner join Marcas Marcs on (Art.IdMarca = Marcs.Id) inner join Categorias Categoris on (Art.IdCategoria = Categoris.Id) ";

                if (id != "")
                    comandoSQL.CommandText += " and Art.Id = "+id;

                comandoSQL.Connection = conexionSQL;
                conexionSQL.Open();
                lectorSQL = comandoSQL.ExecuteReader();

                while (lectorSQL.Read())
                {
                    Articulo articuloAuxiliar = new Articulo();
                    articuloAuxiliar.Id = (int)lectorSQL["Id"];
                    articuloAuxiliar.Codigo = (string)lectorSQL["Codigo"];
                    articuloAuxiliar.Nombre = (string)lectorSQL["Nombre"];
                    articuloAuxiliar.Descripcion = (string)lectorSQL["Descripcion"];

                    // if(!(lectorSQL.IsDBNull(lectorSQL.GetOrdinal("ImagenUrl"))))
                    // articuloAuxiliar.ImagenUrl   = (string)lectorSQL["ImagenUrl"];

                    if (!(lectorSQL["ImagenUrl"] is DBNull))
                        articuloAuxiliar.ImagenUrl = (string)lectorSQL["ImagenUrl"];

                    if (!(lectorSQL["Precio"] is DBNull))
                        articuloAuxiliar.Precio = decimal.Parse(lectorSQL["Precio"].ToString());


                    articuloAuxiliar.Marca = new Marca();
                    articuloAuxiliar.Marca.Id = (int)lectorSQL["IdMarca"];
                    articuloAuxiliar.Marca.Descripcion = (string)lectorSQL["Marca"];
                    articuloAuxiliar.Categoria = new Categoria();
                    articuloAuxiliar.Categoria.Id = (int)lectorSQL["IdCategoria"];
                    articuloAuxiliar.Categoria.Descripcion = (string)lectorSQL["Categoria"];


                    listaArticulos.Add(articuloAuxiliar);
                }
                conexionSQL.Close();
                return listaArticulos;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void addArticulo(Articulo articulo)
        {
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setQuery("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values ('" + articulo.Codigo + "','" + articulo.Nombre + "','" + articulo.Descripcion + "', @idMarca, @idCategoria, @imagenUrl, @precio)");
                data.setearParametro("@idMarca", articulo.Marca.Id);
                data.setearParametro("@idCategoria", articulo.Categoria.Id);
                data.setearParametro("@imagenUrl", articulo.ImagenUrl);
                data.setearParametro("@precio", articulo.Precio);
                data.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }
        }

        public void agregarArticuloSP(Articulo articulo)
        {
            AccesoDatos data = new AccesoDatos();

            try
            {
//                


                data.setearProcedimiento("storedAltaArticulo");
                data.setearParametro("@cod", articulo.Codigo);
                data.setearParametro("@nombre", articulo.Nombre);
                data.setearParametro("@desc", articulo.Descripcion);
                data.setearParametro("@idMarca", articulo.Marca.Id);
                data.setearParametro("@idCategoria", articulo.Categoria.Id);
                data.setearParametro("@img", articulo.ImagenUrl);
                data.setearParametro("@precio", articulo.Precio);
                data.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }
        }
        public void updateArticulo(Articulo articulo)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setQuery("update ARTICULOS SET Codigo=@codigo, Nombre = @nombre, Descripcion = @desc, ImagenUrl = @img, Precio = @precio, IdMarca=@idMarca, IdCategoria = @idCategoria where Id = @id");
                data.setearParametro("@codigo", articulo.Codigo);
                data.setearParametro("@nombre", articulo.Nombre);
                data.setearParametro("@desc", articulo.Descripcion);
                data.setearParametro("@img", articulo.ImagenUrl);
                data.setearParametro("@precio", articulo.Precio);
                data.setearParametro("@idMarca", articulo.Marca.Id);
                data.setearParametro("@idCategoria", articulo.Categoria.Id);
                data.setearParametro("@id", articulo.Id);

                data.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }
        }
        public void modificarArticuloSP(Articulo articulo)
        {
            AccesoDatos data = new AccesoDatos();
            try
            {
                data.setearProcedimiento("StoredModificarArticulo");
                data.setearParametro("@cod", articulo.Codigo);
                data.setearParametro("@nombre", articulo.Nombre);
                data.setearParametro("@desc", articulo.Descripcion);
                data.setearParametro("@img", articulo.ImagenUrl);
                data.setearParametro("@precio", articulo.Precio);
                data.setearParametro("@idMarca", articulo.Marca.Id);
                data.setearParametro("@idCategoria", articulo.Categoria.Id);
                data.setearParametro("@id", articulo.Id);

                data.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.cerrarConexion();
            }
        }


        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos data = new AccesoDatos();
            try
            {
                string query = "select Codigo, Nombre, Art.Descripcion, ImagenUrl, Marcs.Descripcion AS Marca, Categoris.Descripcion AS Categoria, Precio, Art.IdMarca, Art.IdCategoria, Art.Id from Articulos Art inner join Marcas Marcs on (Art.IdMarca = Marcs.Id) inner join Categorias Categoris on (Art.IdCategoria = Categoris.Id) And ";
                if (campo == "Marca")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            query += "Marcs.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            query += "Marcs.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            query += "Marcs.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            query += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            query += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            query += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Categoría")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            query += "Categoris.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            query += "Categoris.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            query += "Categoris.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            query += "Precio > " + filtro ;
                            break;
                        case "Menor a":
                            query += "Precio < " + filtro;
                            break;
                        default:
                            query += "Precio = " + filtro;
                            break;
                    }
                }

                data.setQuery(query);
                data.ejecutarLectura();

                while (data.LectorSQL.Read())
                {
                    Articulo articuloAuxiliar = new Articulo();
                    articuloAuxiliar.Id = (int)data.LectorSQL["Id"];
                    articuloAuxiliar.Codigo = (string)data.LectorSQL["Codigo"];
                    articuloAuxiliar.Nombre = (string)data.LectorSQL["Nombre"];
                    articuloAuxiliar.Descripcion = (string)data.LectorSQL["Descripcion"];

                    if (!(data.LectorSQL["ImagenUrl"] is DBNull))
                        articuloAuxiliar.ImagenUrl = (string)data.LectorSQL["ImagenUrl"];

                    if (!(data.LectorSQL["Precio"] is DBNull))
                        articuloAuxiliar.Precio = decimal.Parse(data.LectorSQL["Precio"].ToString());


                    articuloAuxiliar.Marca = new Marca();
                    articuloAuxiliar.Marca.Id = (int)data.LectorSQL["IdMarca"];
                    articuloAuxiliar.Marca.Descripcion = (string)data.LectorSQL["Marca"];
                    articuloAuxiliar.Categoria = new Categoria();
                    articuloAuxiliar.Categoria.Id = (int)data.LectorSQL["IdCategoria"];
                    articuloAuxiliar.Categoria.Descripcion = (string)data.LectorSQL["Categoria"];


                    lista.Add(articuloAuxiliar);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminar(int id)
        {

            try
            {
                AccesoDatos data = new AccesoDatos();
                data.setQuery("delete from Articulos where Id = @id");
                data.setearParametro("@id", id);
                data.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
    }
}
