﻿using Data_Access_Layer.DTOs;



namespace Data_Access_Layer.Interfaces
{
    public interface IUser_Context 
    {
        public User_DTO AddUser(User_DTO user);
        User_DTO GetByName(User_DTO user);
       
    }
}
