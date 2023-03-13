using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
   public class CategoriaNegocio
    {
        public List<Categoria> listar() {

            List<Categoria> listaCategorias = new List<Categoria>();
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setQuery("select Id, Descripcion from CATEGORIAS");
                data.ejecutarLectura();
                while (data.LectorSQL.Read())
                {
                    Categoria categoriaAuxiliar = new Categoria();
                    categoriaAuxiliar.Id = (int)data.LectorSQL["Id"];
                    categoriaAuxiliar.Descripcion = (string)data.LectorSQL["Descripcion"];
                    listaCategorias.Add(categoriaAuxiliar);
                }
                return listaCategorias;
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
    }
}
