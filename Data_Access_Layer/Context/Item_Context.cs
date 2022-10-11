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
    public class Item_Context : SQLBaseContext, I_Item_Context
    {
        long I_Item_Context.AddItem(Item_DTO item)
        {

            try
            {
                string sql =
                    "INSERT INTO [Items](ItemName, Price, Amount) OUTPUT INSERTED.ItemID VALUES (@ItemName, @Price, @Amount)";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("ItemName", item.ItemName),
                    new KeyValuePair<string, string>("Price", item.Price.ToString()),
                    new KeyValuePair<string, string>("Amount", item.Amount.ToString()),
                };
                int result = ExecuteInsert(sql, parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            throw new NotImplementedException();
        }
   //   public Item_DTO GetByItem(Item_DTO item)
   //   {
   //       try
   //       {
   //           string sql = "SELECT * FROM [Items] WHERE Itemname = @Itemname";
   //           List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
   //           {
   //               new KeyValuePair<string, string>("ItemName", item.ItemName),
   //           };
   //
   //           DataSet results = ExecuteSql(sql, parameters);
   //           Item_DTO v = Parses.Parses.DataSetToItemDTO(results, 0);
   //           int a = v.ItemID;
   //           return v;
   //       }
   //       catch (Exception ex)
   //       {
   //           throw ex;
   //       }
   //   }
    }
}
