using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.DTOs;
using System.Data;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;



namespace Data_Access_Layer.Context
{
    public class User_Context : SQLBaseContext, I_User_Context
    {

        public User_DTO GetByName(User_DTO user)
        {
            try
            {
                string sql = "SELECT * FROM [User] WHERE Username = @Username and Password = @Password";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("Username", user.Username),
                    new KeyValuePair<string, string>("Password", user.Password),
                };

                DataSet results = ExecuteSql(sql, parameters);
                User_DTO b = Parses.Parses.DataSetToAccountDTO(results, 0);
                int a = b.User_ID;
                return b;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Registrated(int id)
        {
            try
            {
                string sql = "Update Account Set Registrated = 1 WHERE User_ID = @User_ID";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("User_ID", id.ToString()),
                };
                ExecuteUpdate(sql, parameters);
            }
            catch (Exception e) 
            {
                throw e;
            }

        }
            
        public long Insert(AccUser_DTO account)
        {
            try
            {
                string sql =
                    "INSERT INTO Account(Username, Password) OUTPUT INSERTED.Account_ID VALUES(@Username,@Password)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Username", account.Username),
                    new KeyValuePair<string, string>("Password", account.Password),
                };
                int result = ExecuteInsert(sql, parameters);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        long I_User_Context.Insert(User_DTO user)
        {
            throw new NotImplementedException();
        }
        //    public bool Login(string username, string password)
        //    {
        //
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            try
        //            {
        //                con.Open();
        //                SqlCommand comm = new SqlCommand("SELECT * FROM UserData WHERE Username = @username AND Password = @password", con);
        //                SqlDataAdapter sda = new SqlDataAdapter(comm);
        //
        //                comm.Parameters.AddWithValue("@username", username.Trim());
        //                comm.Parameters.AddWithValue("@password", password.Trim());
        //
        //                comm.ExecuteNonQuery();
        //                DataTable dt = new DataTable();
        //                sda.Fill(dt);
        //
        //
        //                con.Close();
        //
        //                return dt.Rows.Count != 0;
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine(ex.Message);
        //                return false;
        //            }
        //
        //        }
        //
        //    }
        //  public User_DTO getUser(string username)
        //  {
        //      using (SqlConnection con = new SqlConnection(connectionString))
        //      {
        //          try
        //          {
        //
        //              con.Open();
        //              SqlCommand comm = new SqlCommand("SELECT * FROM UserData WHERE Username = @username", con);
        //
        //              comm.Parameters.AddWithValue("@username", username.Trim());
        //
        //              SqlDataAdapter sda = new SqlDataAdapter(comm);
        //              comm.ExecuteNonQuery();
        //              DataTable dt = new DataTable();
        //              sda.Fill(dt);
        //              var row = dt.Rows[0];
        //
        //              return new User_DTO
        //              {
        //                  
        //                  Username = row.Field<string>("Username"),
        //                  Password = row.Field<string>("Password"),
        //                  Email = row.Field<string>("Email")
        //              };
        //
        //          }
        //
        //          catch (Exception ex)
        //          {
        //              Console.WriteLine(ex.Message);
        //              return null;
        //          }
        //      }
        //  }
    }
}
