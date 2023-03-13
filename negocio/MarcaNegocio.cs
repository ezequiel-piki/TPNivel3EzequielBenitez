using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {

            List<Marca> listaMarcas = new List<Marca>();
            AccesoDatos data = new AccesoDatos();

            try
            {
                data.setQuery("select Id, Descripcion from MARCAS");
                data.ejecutarLectura();
                while (data.LectorSQL.Read())
                {
                    Marca marcaAuxiliar = new Marca();
                    marcaAuxiliar.Id = (int)data.LectorSQL["Id"];
                    marcaAuxiliar.Descripcion = (string)data.LectorSQL["Descripcion"];
                    listaMarcas.Add(marcaAuxiliar);
                }
                return listaMarcas;
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
