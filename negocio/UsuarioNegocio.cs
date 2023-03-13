using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace negocio
{
    public class UsuarioNegocio
    {
        public void actualizar(Usuario usuario)
        {
                AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setQuery("UPDATE USERS set email=@email, nombre = @nombre, apellido = @apellido, urlImagenPerfil = @img where Id = @id");
                accesoDatos.setearParametro("@email", usuario.Email);
                accesoDatos.setearParametro("@nombre", usuario.Nombre);
                accesoDatos.setearParametro("@apellido", usuario.Apellido);
                //accesoDatos.setearParametro("@img", usuario.ImagenUrl != null ? usuario.ImagenUrl :(object)DBNull.Value); 
                accesoDatos.setearParametro("@img",(object) usuario.ImagenUrl ?? DBNull.Value);
                accesoDatos.setearParametro("@id", usuario.Id);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            } finally { accesoDatos.cerrarConexion(); }
        }

        

        public int InsertarNuevo(Usuario usuarioNuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametro("@email", usuarioNuevo.Email);
                datos.setearParametro("@pass", usuarioNuevo.Pass);
               return datos.ejecutarAccionScalar();
               
            }
            catch (Exception ex)
            {

                throw ex;
            } finally { datos.cerrarConexion(); }
           
        }

        public int registrarUsuario(Usuario usuarioNuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("insert into USERS (email,pass,admin) output inserted.id values (@email,@pass,0)");
                datos.setearParametro("@email", usuarioNuevo.Email);
                datos.setearParametro("@pass", usuarioNuevo.Pass);
                return datos.ejecutarAccionScalar();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }

        public bool Login (Usuario usuario)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {   
                accesoDatos.setQuery("select id, email, pass, nombre, apellido, admin, urlImagenPerfil from USERS where email=@email and pass=@pass");
                accesoDatos.setearParametro("@email", usuario.Email);
                accesoDatos.setearParametro("@pass", usuario.Pass);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.LectorSQL.Read())
                {
                    usuario.Id = (int)accesoDatos.LectorSQL["id"];
                    usuario.Admin = (bool)accesoDatos.LectorSQL["admin"];


                    if (!(accesoDatos.LectorSQL["nombre"] is DBNull))
                    {
                        usuario.Nombre = (string)accesoDatos.LectorSQL["nombre"];

                    }


                    if (!(accesoDatos.LectorSQL["apellido"] is DBNull))
                    {
                        usuario.Apellido = (string)accesoDatos.LectorSQL["apellido"];

                    }


                    if (!(accesoDatos.LectorSQL["urlImagenPerfil"] is DBNull))
                    {
                        usuario.ImagenUrl = (string)accesoDatos.LectorSQL["urlImagenPerfil"];
                  
                    }

                    return true;
                }

                return false;
            
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally { accesoDatos.cerrarConexion(); }
        }
    }
}
