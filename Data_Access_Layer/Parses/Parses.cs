using Data_Access_Layer.DTOs;
using System.Data;

namespace Data_Access_Layer.Parses
{
    public class Parses
    {
        public static User_DTO DataSetToAccountDTO(DataSet set, int rowIndex)
        {
            if (set.Tables[0].Rows.Count > 0)
            {
                return new User_DTO((int)set.Tables[0].Rows[rowIndex][4])
                {
                    Username = (string)set.Tables[0].Rows[rowIndex][1],
                    Password = " ",
                };
            }
            else
            {
                return new User_DTO();
            }
        }
    }
}
