using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad01.Datos.Utils
{
    public class DataHelper
    {
        private static DataHelper _instancia;
        public SqlConnection conexion;

        private DataHelper()
        {
            conexion = new SqlConnection(Properties.Resources.CadenaConexion);
        }

        public static DataHelper GetInstance()
        {
            if (_instancia == null)
            { _instancia = new DataHelper(); };

            return _instancia;
        }

        public DataTable ExecuteSpQuery(string sp, List<ParameterSQL>? list)
        {
            var table = new DataTable();

            try
            {
                conexion.Open();
                var cm = new SqlCommand(sp, conexion);
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                if (list != null)
                {
                    foreach (var param in list)
                    {
                        cm.Parameters.AddWithValue(param.Nombre, param.Valor);
                    }
                }     
                table.Load(cm.ExecuteReader());

            }
            catch (SqlException)
            {
                table = null;
            }
            conexion.Close();
            return table;
        }

        public int ExecuteSPDML(string sp, List<ParameterSQL>? list)
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

        public SqlConnection GetConnection()
        {
            return conexion;
        }
    }
}
