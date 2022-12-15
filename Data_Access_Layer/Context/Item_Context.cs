using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace Data_Access_Layer.Context
{
    public class Item_Context : SQLBaseContext, IItem_Context
    {
        public void SendEmail()
        {
            string to = "h.brouwer@student.fontys.nl"; //To address    
            string from = "h.brouwer@student.fontys.nl"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
            message.Subject = "Sending Email Using Asp.Net & C#";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.live.com", 587); //Outlook smpt  
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("h.brouwer@student.fontys.nl", "Bebtamparmu6");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
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
                ConClose();
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
            {

                var sql = "DELETE FROM [Items] WHERE ItemID = @ItemID";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@ItemID", id);
                cmd.ExecuteNonQuery();

                transaction.Commit();
                ConClose();
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
                ConClose();
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

        public Item_DTO AddItemToUser(Item_DTO item, User_DTO user, int amount)
        {
            ConOpen();
            SqlTransaction transaction;
            transaction = this.Con.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.Con;
            cmd.Transaction = transaction;
            try
            {
                var sql = "INSERT INTO [dbo].[UserItems]([UserID],[ItemID],[AmountOwned],[OwnedItem]) VALUES(@UserID, @ItemID, @AmountOwned, @OwnedItem)";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@UserID", user.User_ID);
                cmd.Parameters.AddWithValue("@ItemID", item.ItemID);
                cmd.Parameters.AddWithValue("@AmountOwned", amount);
                cmd.Parameters.AddWithValue("@OwnedItem", item.ItemName);
                cmd.ExecuteNonQuery();

                var sql2 = "UPDATE [dbo].[Items] SET Amount=Amount - @amount WHERE ItemID=@idItem";
                                                                                                   
                cmd.CommandText = sql2;
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@idItem", item.ItemID);
                cmd.ExecuteNonQuery();

                transaction.Commit();
                ConClose();
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
            ConClose();
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
                ConClose();
            }

            catch (Exception ex)
            {

            }

        }

        public Item_DTO DoubleItems(Item_DTO item, User_DTO user, int Amount)
        {
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
                cmd.Parameters.AddWithValue("@AmountOwned", Amount);
                cmd.Parameters.AddWithValue("@OwnedItem", item.ItemName);
                cmd.ExecuteNonQuery();

                var sql2 = "UPDATE [dbo].[Items] SET Amount=Amount - @amount WHERE ItemID=@idItem";// "INSERT U.UserID, I.ItemID FROM [User] as U, Items as I, UserItems as UI Where U.UserID = @UI.UserID AND I.ItemID = UI.ItemID";
                                                                                                   //   if ("Amount=Amount - @amount">= 0) { 
                cmd.CommandText = sql2;
                cmd.Parameters.AddWithValue("@amount", Amount);
                cmd.Parameters.AddWithValue("@idItem", item.ItemID);
                cmd.ExecuteNonQuery();

                transaction.Commit();
            }

            catch (Exception ex)
            {
                transaction.Rollback();
            }
            ConClose();
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
                if (Amount > 0)
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

        public Item_DTO GetItemData(Item_DTO item)
        {
            try
            {
                ConOpen();
                var sql = "SELECT * FROM Items WHERE ItemID = @ItemID";
                SqlCommand cmd = new SqlCommand(sql, this.Con);
                cmd.Parameters.AddWithValue("@ItemID", item.ItemID);
                cmd.ExecuteNonQuery();
                item = new Item_DTO();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    item = new Item_DTO
                    {
                        ItemID = rdr.GetInt32("ItemID"),
                        Price = rdr.GetInt32("Price"),
                        ItemName = rdr.GetString("ItemName"),
                        TotalItems = rdr.GetInt32("Amount")
                    };
                }


                ConClose();
                return item;
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
    }
}









