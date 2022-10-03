using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data_Access_Layer.DTOs;

namespace Data_Access_Layer.Parses
{
    public class Parses
    {
        public static User_DTO DataSetToAccountDTO(DataSet set, int rowIndex)
        {
            if (set.Tables[0].Rows.Count > 0)
            {
                return new User_DTO((int)set.Tables[0].Rows[rowIndex][0])
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
