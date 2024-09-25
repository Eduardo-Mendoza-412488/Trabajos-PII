using Microsoft.Azure.Amqp.Framing;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticuloLibreria.Datos.Utils
{
    public class DataHelper
    {
        private static DataHelper instancia = null;
        private SqlConnection conexion;

        private DataHelper()
        {
            conexion = new SqlConnection(Properties.Resources.CadConexion);
        }

        public static DataHelper GetInstancia()
        {
            if (instancia == null)
                instancia = new DataHelper();
            return instancia;
        }

        public SqlConnection GetConnection()
        {
            return conexion;
        }

        public DataTable Consultar(string nombreSP, List<SqlParameter>? parameters = null)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;

            if (parameters != null)
            {
                foreach (var param in parameters)
                    comando.Parameters.AddWithValue(param.ParameterName, param.Value);
            }

            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }



        public int Ejecutar(string sp, List<ParameterSQL>? list)
        {
            int rows;

            try
            {
                conexion.Close();
                conexion.Open();
                var cm = new SqlCommand(sp, conexion);
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (ParameterSQL param in list)
                {
                    cm.Parameters.AddWithValue(param.Nombre, param.Valor);
                }
                rows = cm.ExecuteNonQuery();

            }
            catch (SqlException)
            {
                rows = 0;
            }
            conexion.Close();

            return rows;
        }
    }
}
