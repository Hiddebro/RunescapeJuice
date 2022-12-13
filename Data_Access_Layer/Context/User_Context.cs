using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Data.SqlClient;




namespace Data_Access_Layer.Context
{
    public class User_Context : SQLBaseContext, IUser_Context
    {

        public User_DTO GetByName(User_DTO user)
        {
            try
            {

                ConOpen();
                var sql = "SELECT * FROM [User] WHERE Username = @Username and Password = @Password";
                SqlCommand cmd = new SqlCommand(sql, this.Con);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    user = new User_DTO
                    {
                        Username = rdr.GetString("Username"),
                        Password = rdr.GetString("Password"),
                        User_ID = rdr.GetInt32("UserID"),
                        IsAdmin = rdr.GetInt32("IsAdmin")
                    };
                }
                ConClose();
                return (user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }




        public User_DTO AddUser(User_DTO user)
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
                        ConClose();
                        return user;
                    }
                    return user;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return user;
            }
        }

        public bool CheckActorr(User_DTO user)
        {
            try
            {
                ConOpen();
                var sql = "SELECT * FROM [User] WHERE UserID = @User_ID";
                SqlCommand cmd = new SqlCommand(sql, this.Con);
                cmd.Parameters.AddWithValue("@User_ID", user.User_ID);
                cmd.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                if (user.IsAdmin == 1)
                {
                    ConClose();
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            ConClose();
            return false;
        }
    }
}





