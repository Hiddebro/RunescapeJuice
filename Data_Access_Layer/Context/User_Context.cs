using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;
using System.Data;
using System.Data.SqlClient;



namespace Data_Access_Layer.Context
{
    public class User_Context : SQLBaseContext, I_User_Context
    {

        public User_DTO GetByName(User_DTO user)
        {
            try
            {
                {
                    ConOpen();
                    var sql = "SELECT * FROM [User] WHERE Username = @Username and Password = @Password";
                    SqlCommand cmd = new SqlCommand(sql, this.Con);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    Console.WriteLine("Succesful Loged in");
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    var row = dt.Rows[0];
                    user.User_ID = row.Field<int>("UserID");
                    user.IsAdmin = row.Field<int>("IsAdmin");

                    return (user);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public User_DTO GetByIsAdmin(User_DTO user)
        {
            try
            {
                ConOpen();
                var sql = "SELECT * FROM [User] WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(sql, this.Con);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                var row = dt.Rows[0];
                user.IsAdmin = row.Field<int>("IsAdmin");
                return (user);
            }
            catch
            {
                return null;
            }
        }



        public bool AddUser(User_DTO user)
        {
            try
            {
                {
                    ConOpen();
                    var sql = "IF NOT EXISTS(SELECT * FROM [USER] WHERE Username = @Username) INSERT INTO [User](Username, Password,IsAdmin) VALUES (@Username, @Password, @IsAdmin)";
                    SqlCommand cmd = new SqlCommand(sql, this.Con);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
                    Console.WriteLine("Succesful Registerd");
                    var Com = cmd.ExecuteNonQuery();
                    if (Com >= 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }



    }
}
