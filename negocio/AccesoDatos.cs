using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace negocio
{
   public class AccesoDatos
    {
        private SqlConnection conexionSQL;
        private SqlCommand comandoSQL;
        private SqlDataReader lectorSQL;

        public SqlDataReader LectorSQL
        {
            get { return lectorSQL; }
        }


        public AccesoDatos()
        {
            conexionSQL = new SqlConnection(ConfigurationManager.AppSettings["cadenaConexion"]); ;
            comandoSQL = new SqlCommand();
        }

        public void setearProcedimiento(string sp)
        {
            comandoSQL.CommandType = System.Data.CommandType.StoredProcedure;
            comandoSQL.CommandText = sp;
        }
        public void setQuery(string query)
        {
            comandoSQL.CommandType = System.Data.CommandType.Text;
            comandoSQL.CommandText = query;
        }

        public void ejecutarLectura()
        {
            comandoSQL.Connection = conexionSQL;
            try
            {

            conexionSQL.Open();
            lectorSQL = comandoSQL.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ejecutarAccionScalar()
        {
            comandoSQL.Connection = conexionSQL;
            try
            {

                conexionSQL.Open();
                return int.Parse( comandoSQL.ExecuteScalar().ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ejecutarAccion()
        {
            comandoSQL.Connection = conexionSQL;
            try
            {

                conexionSQL.Open();
                comandoSQL.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            comandoSQL.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if (lectorSQL != null)
                lectorSQL.Close();
            conexionSQL.Close();
        }
    }
}
