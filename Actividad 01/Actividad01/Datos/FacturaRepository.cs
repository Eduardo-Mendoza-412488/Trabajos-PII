using Actividad01.Datos.Utils;
using Actividad01.Dominio;
using System.Data;
using System.Data.SqlClient;

namespace Actividad01.Datos
{
    public class FacturaRepository : IFacturaRepository
    {
        public List<Factura> GetAll()
        {
            var lista = new List<Factura>();
            var helper = DataHelper.GetInstance();
            var t = helper.ExecuteSpQuery("SP_RECUPERAR_FACTURA", null);
            foreach (DataRow row in t.Rows)
            {
                int id = Convert.ToInt32(row["nro_factura"]);
                
                DateTime fecha = Convert.ToDateTime(row["fecha"]);
                string formaPago = row["forma_pago"].ToString();
                string cliente = row["cliente"].ToString();
                bool activo = Convert.ToBoolean(row["esta_activo"]);

                var oFormPago = new FormaPago()
                {
                    FormPago = formaPago
                };

                var oFactura = new Factura()
                {
                    Id = id,
                    Fecha = fecha,
                    FormPago = oFormPago,
                    Cliente = cliente,
                    Activo = activo
                };
                lista.Add(oFactura);
            }
            return lista;

        }

        public List<DetalleFactura> GetDetallesById(int id)
        {
            var parameters = new List<ParameterSQL>();
            parameters.Add(new ParameterSQL("@codigo", id));
            var t = DataHelper.GetInstance().ExecuteSpQuery("SP_RECUPERAR_DETALLE_FACTURA", parameters);
            var lista = new List<DetalleFactura>();

            if (t != null)
            {
                foreach (DataRow row in t.Rows)
                {
                    string articulo = row["articulo"].ToString();
                    int cantidad = Convert.ToInt32(row["cantidad"]);

                    var oArticulo = new Articulo()
                    {
                        Nombre = articulo
                    };
                    var oDetalle = new DetalleFactura()
                    {
                        Art = oArticulo,
                        Cantidad = cantidad
                    };
                    lista.Add(oDetalle);
                }
                return lista;

            }
            return null;
        }
        int nroDetail = 3;
        public bool Save(Factura oFactura)
        {
            bool result = true;
            SqlTransaction? t = null;
            SqlConnection? cnn = null;

            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();

                var cmd = new SqlCommand("SP_GUARDAR_MAESTRO", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                //parámetro de entrada:
                cmd.Parameters.AddWithValue("@codigo", oFactura.Id);
                cmd.Parameters.AddWithValue("@codFPago", oFactura.FormPago.Id);
                cmd.Parameters.AddWithValue("@cliente", oFactura.Cliente);
                //parámetro de salida:
                SqlParameter param = new SqlParameter("@id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                int facturaId = (int)param.Value;
                foreach (DetalleFactura detail in oFactura.Detalle)
                {
                    var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLES", cnn, t);
                    cmdDetail.CommandType = CommandType.StoredProcedure;
                    cmdDetail.Parameters.AddWithValue("@codigo", nroDetail);
                    cmdDetail.Parameters.AddWithValue("@nroFactura", facturaId);
                    cmdDetail.Parameters.AddWithValue("@idArt", detail.Art.Codigo);
                    cmdDetail.Parameters.AddWithValue("@cantidad", detail.Cantidad);
                    cmdDetail.ExecuteNonQuery();
                    nroDetail++;
                }

                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                result = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
            }
            return result;
        }

        public bool InsertarDetalles(DetalleFactura oDetalle)
            {
                bool result = true;
                string query = "SP_INSERTAR_DETALLES";

            try
            {
                if (oDetalle != null)
                {
                    var parametros = new List<ParameterSQL>();
                    parametros.Add(new ParameterSQL("@codigo", oDetalle.Id));
                    parametros.Add(new ParameterSQL("@idArt", oDetalle.Art.Codigo));
                    parametros.Add(new ParameterSQL("@cantidad", oDetalle.Cantidad));
                    result = DataHelper.GetInstance().ExecuteSPDML(query, parametros) == 1;
                }
        }
            catch (SqlException sqlEx)
                {
                    result = false;
                }
                return result;
            }

        public bool Delete(int id)
            {
                var parameters = new List<ParameterSQL>();
                parameters.Add(new ParameterSQL("@codigo", id));
                int rows = DataHelper.GetInstance().ExecuteSPDML("SP_BAJA_FACTURA", parameters);
                return rows == 1;
            }
        }
    }
