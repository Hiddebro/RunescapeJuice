using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;
using System.Data.SqlClient;


namespace Data_Access_Layer.Context
{
    public class Item_Context : SQLBaseContext, I_Item_Context
    {
        public Item_DTO AddItem(Item_DTO item)
        {

            try
            {
                ConOpen();
                var sql = "IF NOT EXISTS(SELECT * FROM [Items] WHERE ItemName = @ItemName) INSERT INTO [Items](ItemName, Price, Amount) VALUES (@ItemName, @Price, @Amount)";
                SqlCommand cmd = new SqlCommand(sql, this.Con);
                cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
                cmd.Parameters.AddWithValue("@Price", item.Price);
                cmd.Parameters.AddWithValue("@Amount", item.Amount);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Succesful Item Added");
                return (item);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            throw new NotImplementedException();
        }



    }
}
