using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Data_Access_Layer.Context
{
    public class SQLBaseContext
    {
        public string _ConnectionString;

        public SQLBaseContext()
        {
            _ConnectionString = "Server = mssqlstud.fhict.local; Database = dbi439802_webshophid; User Id = dbi439802_webshophid; Password = Hidde012";
           
        }

        public DataSet ExecuteSql(string sql, List<KeyValuePair<string, string>> parameters)
        {
            DataSet data = new DataSet();
            try
            {
                SqlConnection connection = new SqlConnection(_ConnectionString);
                SqlDataAdapter Adapter = new SqlDataAdapter();
                SqlCommand command = connection.CreateCommand();

                command.Parameters.AddRange(GetParameters(parameters));
                command.CommandText = sql;

                Adapter.SelectCommand = command;

                connection.Open();

                Adapter.Fill(data);
                connection.Close();

                return data;
            }
            catch (Exception e)
            { 
                throw e;
            }
        }

        private SqlParameter[] GetParameters(List<KeyValuePair<string, string>> parameters)
        {
            SqlParameter[] retVal = new SqlParameter[parameters.Count];
            foreach (KeyValuePair<string, string> kvp in parameters)
            {
                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@" + kvp.Key,
                    Value = kvp.Value
                };
                retVal[parameters.IndexOf(kvp)] = param;
            }
            return retVal;
        }
        public void ExecuteUpdate(string sql, List<KeyValuePair<string, string>> parameters)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_ConnectionString);
                SqlCommand command = new SqlCommand();
                command = connection.CreateCommand();

                command.Parameters.AddRange(GetParameters(parameters));
                command.CommandText = sql;

                connection.Open();
                command.ExecuteScalar();
                connection.Close();
            }
            catch (Exception es)
            {
                throw es;
            }
        }

        public int ExecuteInsert(string sql, List<KeyValuePair<string, string>> parameters)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_ConnectionString);
                SqlCommand command = new SqlCommand();
                command = connection.CreateCommand();

                command.Parameters.AddRange(GetParameters(parameters));
                command.CommandText = sql;

                connection.Open();
                int id = (int)command.ExecuteScalar();
                connection.Close();

                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
