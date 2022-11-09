using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer.Context
{
    public class ActorCheck_Context : SQLBaseContext, IActorCheck
    {
      public bool CheckActor(User_DTO user)
      {
          try
          {
              ConOpen();
              var sql = "SELECT * FROM [User] WHERE User_ID = @UserID";
              SqlCommand cmd = new SqlCommand(sql, this.Con);
              cmd.Parameters.AddWithValue("@UserID", user.User_ID);
              SqlDataAdapter sda = new SqlDataAdapter(cmd);
              cmd.ExecuteNonQuery();
              DataTable dt = new DataTable();
              sda.Fill(dt);
              var row = dt.Rows[0];
              user.IsAdmin = row.Field<int>("IsAdmin");
                if (user.IsAdmin == 1)
                {
                    return true;
                }
              
              
          }
          catch (Exception ex)
          {
     
          }
            
                return false;
            
      }
    }
}
