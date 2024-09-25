using ArticuloLibreria.Datos.Utils;
using ArticuloLibreria.Dominio;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticuloLibreria.Datos
{
    public class RepositoryArticulo : IRepositoryArticulo
    {
        public bool Delete(int id)
        {
            var parameters = new List<ParameterSQL>();
            parameters.Add(new ParameterSQL("@codigo", id));
            int rows = DataHelper.GetInstancia().Ejecutar("BAJA_ARTICULO", parameters);
            return rows == 1;
        }

        public List<Articulo> GetAll()
        {
            var lista = new List<Articulo>();
            var helper = DataHelper.GetInstancia();
            var t = helper.Consultar("RECUPERAR_ARTICULOS", null);
            foreach (DataRow row in t.Rows)
            {
                int id = Convert.ToInt32(row["id_articulo"]);
                string articulo = row["articulo"].ToString();
                bool estado = Convert.ToBoolean(row["estado"]);

                var oArticulo = new Articulo()
                {
                    Id = id,
                    Art = articulo,
                    Estado = estado

                };
                lista.Add(oArticulo);
            }
            return lista;
        }

        public Articulo GetById(int id)
        {
            var helper = DataHelper.GetInstancia();
            var t = helper.Consultar("RECUPERAR_ARTICULOxID", null);

            int Id = Convert.ToInt32(t.Rows[0]);
            string articulo = t.Rows[1].ToString();
            bool estado = Convert.ToBoolean(t.Rows[2]);

            var oArticulo = new Articulo()
            {
                Id = Id,
                Art = articulo,
                Estado = estado
            };
            return oArticulo;
        }

        public bool Save(Articulo oArticulo)
        {
            bool result = true;
            SqlConnection? cnn = null;

            try
            {
                cnn = DataHelper.GetInstancia().GetConnection();
                cnn.Open();

                var cmd = new SqlCommand("SP_GUARDAR_ARTICULO", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                //parámetro de entrada:
                cmd.Parameters.AddWithValue("@codigo", oArticulo.Id);
                cmd.Parameters.AddWithValue("@articulo", oArticulo.Art);
                cmd.ExecuteNonQuery();
            }

            catch (SqlException)
            {
                result = false;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return result;
        }
    }
}
