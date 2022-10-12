using System.Data.SqlClient;

namespace Data_Access_Layer.Context
{
    public class SQLBaseContext
    {
        public string _ConnectionString;

        public SQLBaseContext()
        {
            _ConnectionString = "Server = mssqlstud.fhict.local; Database = dbi439802_webshophid; User Id = dbi439802_webshophid; Password = Hidde012";
        }
        public SqlConnection Con { get; set; }
        public void ConOpen()
        {
            try
            {
                Con = new SqlConnection(_ConnectionString);
                this.Con.Open();
                // if not exist
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void ConClose()
        {
            try
            {
                this.Con.Close();
                // if not exist
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

