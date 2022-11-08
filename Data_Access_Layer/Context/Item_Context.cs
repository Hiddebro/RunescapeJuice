using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;
using System.Data;
using System.Data.SqlClient;


namespace Data_Access_Layer.Context
{
    public class Item_Context : SQLBaseContext, IItem_Context
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

        public void DeleteItem(int id)
        {
            try
            {
                ConOpen();
                var sql = "DELETE FROM [Items] WHERE ItemID = @ItemID";
                SqlCommand cmd = new SqlCommand(sql, this.Con);
                cmd.Parameters.AddWithValue("@ItemID", id);
                cmd.ExecuteNonQuery();
               
        
            }

            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public List<Item_DTO> GetAllItems()
        {
            List<Item_DTO> list = new List<Item_DTO>();
            try
            {
                Item_DTO item = null;
                ConOpen();
                var sql = "SELECT * FROM Items";
                SqlCommand cmd = new SqlCommand(sql, this.Con);
                SqlDataReader rdr = cmd.ExecuteReader();
               
              
                while (rdr.Read())
                {
                    item = new Item_DTO
                    {
                        ItemID = rdr.GetInt32("ItemID"),
                        ItemName = rdr.GetString("ItemName"),
                        Price = rdr.GetInt32("Price"),
                        Amount = rdr.GetInt32("Amount")
                    };

                    list.Add(item);                      

                }



                return list ;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ConClose();
            }
            throw new NotImplementedException();
        }
    }
}

       
        


    

