using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace product
{
    public class AccesoDatos
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;

        public SqlDataReader Reader
        {
            get { return reader; }
        }

        public AccesoDatos()
        {
            conn = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true");
            cmd = new SqlCommand();
        }

        public void toSetQuery(string query)
        {
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
        }

        public void toExecuteReader()
        {
            cmd.Connection = conn;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void toExcecuteNonQuery()
        {
            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int toExcecuteScalar()
        {
            cmd.Connection = conn;

            try
            {
                conn.Open();
                return int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void toSetParameter(string name, object value)
        {
            cmd.Parameters.AddWithValue(name, value);
        }

        public void toClearParameter()
        {
            cmd.Parameters.Clear();
        }

        public void toCloseConnection()
        {
            if (reader != null)
            {
                reader.Close();
            }

            conn.Close();
        }
    }
}
