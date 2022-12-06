using System.Data.SqlClient;

namespace Data_Access_Layer.Context
{
    public abstract class SQLBaseContext
    {
        private string _ConnectionString = "Server = mssqlstud.fhict.local; Database = dbi439802_webshophid; User Id = dbi439802_webshophid; Password = Hidde012";
        public SqlConnection Con { get; set; }
        public void ConOpen()
        {
            try
            {
                Con = new SqlConnection(_ConnectionString);
                this.Con.Open();
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

