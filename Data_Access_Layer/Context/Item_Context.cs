using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;
using Microsoft.AspNetCore.Http;
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

            }
            throw new NotImplementedException();
        }

        public void DeleteItem(int id)
        {
            ConOpen();
            SqlTransaction transaction;
            transaction = this.Con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.Con;
            cmd.Transaction = transaction;
            try

            { var sql2 = "DELETE FROM [Reviews] WHERE ItemID = @IDItem";
                cmd.CommandText = sql2;
                cmd.Parameters.AddWithValue("@IDItem", id);
                cmd.ExecuteNonQuery();

                var sql = "DELETE FROM [Items] WHERE ItemID = @ItemID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ItemID", id);
                cmd.ExecuteNonQuery();

               

                transaction.Commit();
            }

            catch (Exception ex)
            {
                transaction.Rollback();
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
                        Price = rdr.GetInt32("Price"),
                        ItemName = rdr.GetString("ItemName"),
                        Amount = rdr.GetInt32("Amount")
                    };

                    list.Add(item);

                }



                return list;
            }

            catch (Exception ex)
            {

            }
            finally
            {
                ConClose();
            }
            throw new NotImplementedException();
        }

        public Item_DTO AddItemToUser(Item_DTO item, User_DTO user)
        {//wat doe een transaction opzoeken
            ConOpen();
            SqlTransaction transaction;
            transaction = this.Con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.Con;
            cmd.Transaction = transaction;
            try
            {
                var sql = "INSERT INTO [dbo].[UserItems]([UserID],[ItemID],[AmountOwned],[OwnedItem]) VALUES(@UserID, @ItemID, @AmountOwned, @OwnedItem)";// "INSERT U.UserID, I.ItemID FROM [User] as U, Items as I, UserItems as UI Where U.UserID = @UI.UserID AND I.ItemID = UI.ItemID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@UserID", user.User_ID);
                cmd.Parameters.AddWithValue("@ItemID", item.ItemID);
                cmd.Parameters.AddWithValue("@AmountOwned", item.Amount);
                cmd.Parameters.AddWithValue("@OwnedItem", item.ItemName);
                cmd.ExecuteNonQuery();


                var sql2 = "UPDATE [dbo].[Items] SET Amount=Amount - @amount WHERE ItemID=@idItem";// "INSERT U.UserID, I.ItemID FROM [User] as U, Items as I, UserItems as UI Where U.UserID = @UI.UserID AND I.ItemID = UI.ItemID";
                                                                                                   //   if ("Amount=Amount - @amount">= 0) { 
                cmd.CommandText = sql2;
                cmd.Parameters.AddWithValue("@amount", item.Amount);
                cmd.Parameters.AddWithValue("@idItem", item.ItemID);
                cmd.ExecuteNonQuery();

                transaction.Commit();
            }

            catch (Exception ex)
            {
                transaction.Rollback();
            }
            return item;
        }

        public List<Item_DTO> GetAllUserItems(User_DTO user)
        {
            List<Item_DTO> list = new List<Item_DTO>();
            try
            {
                Item_DTO item = null;
                ConOpen();
                var sql = "SELECT [ItemID],[AmountOwned],[OwnedItem] FROM [dbo].[UserItems] WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(sql, this.Con);
                cmd.Parameters.AddWithValue("@UserID", user.User_ID);
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    item = new Item_DTO
                    {
                        ItemID = rdr.GetInt32("ItemID"),
                        ItemName = rdr.GetString("OwnedItem"),
                        Amount = rdr.GetInt32("AmountOwned")
                    };

                    list.Add(item);

                }
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public void SellItem(int id, int userID, int amount)
        {
            ConOpen();
            SqlTransaction transaction;
            transaction = this.Con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.Con;
            cmd.Transaction = transaction;
            try
            {

                var sql = "DELETE FROM [UserItems] WHERE ItemID = @ItemID AND UserID = @UserID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ItemID", id);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.ExecuteNonQuery();

                var sql2 = "UPDATE [dbo].[Items] SET Amount=Amount + @amount WHERE ItemID=@idItem";
                cmd.CommandText = sql2;
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@idItem", id);
                cmd.ExecuteNonQuery();

                transaction.Commit();
            }

            catch (Exception ex)
            {

            }

        }

        public Item_DTO DoubleItems(Item_DTO item, User_DTO user)
        {//wat doe een transaction opzoeken q
            ConOpen();
            SqlTransaction transaction;
            transaction = this.Con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.Con;
            cmd.Transaction = transaction;
            try
            {
                var sql = "UPDATE [dbo].[UserItems] SET AmountOwned=AmountOwned + @AmountOwned WHERE ItemID=@ItemID AND UserID=@UserID";// "INSERT U.UserID, I.ItemID FROM [User] as U, Items as I, UserItems as UI Where U.UserID = @UI.UserID AND I.ItemID = UI.ItemID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@UserID", user.User_ID);
                cmd.Parameters.AddWithValue("@ItemID", item.ItemID);
                cmd.Parameters.AddWithValue("@AmountOwned", item.Amount);
                cmd.Parameters.AddWithValue("@OwnedItem", item.ItemName);
                cmd.ExecuteNonQuery();
                
                var sql2 = "UPDATE [dbo].[Items] SET Amount=Amount - @amount WHERE ItemID=@idItem";// "INSERT U.UserID, I.ItemID FROM [User] as U, Items as I, UserItems as UI Where U.UserID = @UI.UserID AND I.ItemID = UI.ItemID";
                                                                                                   //   if ("Amount=Amount - @amount">= 0) { 
                cmd.CommandText = sql2;
                cmd.Parameters.AddWithValue("@amount", item.Amount);
                cmd.Parameters.AddWithValue("@idItem", item.ItemID);
                cmd.ExecuteNonQuery();

                transaction.Commit();
            }

            catch (Exception ex)
            {
                transaction.Rollback();
            }
            return item;

        }

        public bool CheckIfOwned(int item, int user)
        {
            try
            {
                int Amount = 0;
                ConOpen();
                var sql = "SELECT * FROM [UserItems] WHERE ItemID = @ItemID AND UserID = @UserID";
                SqlCommand cmd = new SqlCommand(sql, this.Con);
               
                cmd.Parameters.AddWithValue("@ItemID", item);
                cmd.Parameters.AddWithValue("@UserID", user);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    {
                         Amount = rdr.GetInt32("AmountOwned");
                    };

                }
                if(Amount > 0)
                {
                    return true;
                }
  
            }

            catch (Exception ex)
            {
                
            }return false;
           
        }

        public Review_DTO AddReview(Review_DTO review_DTO)
        {
            try
            {
                ConOpen();
                var sql = "INSERT INTO[dbo].[Reviews] ([Score] ,[Review] ,[ItemID]) VALUES (@Score, @review,@ItemID)";
                SqlCommand cmd = new SqlCommand(sql, this.Con);
                cmd.Parameters.AddWithValue("@ItemID", review_DTO.ItemID);
                cmd.Parameters.AddWithValue("@Score", review_DTO.Score);
                cmd.Parameters.AddWithValue("@Review", review_DTO.Review);
                cmd.ExecuteNonQuery();


                Console.WriteLine("Succesful Item Added");
                return review_DTO;
            }

            catch (Exception ex)
            {

            }
            throw new NotImplementedException();
        }

        public List<Review_DTO> GetAllReviews(int itemid)
        {
            List<Review_DTO> list = new List<Review_DTO>();
            try
            {
                Review_DTO review = null;
                ConOpen();
                var sql = "SELECT * FROM Reviews WHERE ItemID = @ItemID";
                SqlCommand cmd = new SqlCommand(sql, this.Con);
                cmd.Parameters.AddWithValue("@ItemID", itemid);
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    review = new Review_DTO();
                    {

                        review.ItemID = rdr.GetInt32("ItemID");
                        review.Review = rdr.GetString("Review");
                        review.Score = rdr.GetInt32("Score");
                    };

                    list.Add(review);

                }


            }
            catch (Exception ex)
            {

            }

        
                return list;
            }
         }






    }



       
        


    

