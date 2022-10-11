﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_logic_Layer.Converters;
using Business_logic_Layer.Container;
using Business_logic_Layer.Models;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Context;


namespace Business_logic_Layer.Container
{
    public class User_Container
    {
          private I_User_Context user_Context;
          private readonly User_Converter converter = new User_Converter();

        public User_Container(I_User_Context context)
        {
            this.user_Context = context;
        }

  //   public AccUser_Model GetById(int id)
  //   {
  //       AccUser_Model accuser = new AccUser_Model();
  //       AccUser_DTO dto = user_Context.GetById(id);
  //       accuser = converter.DtoToModel(dto);
  //       return accuser;
  //   }

        public bool AddUser(User_Model user_Model)
       {
           User_DTO dto = new User_DTO();
           dto = converter.ModelToDTO(user_Model);
           return user_Context.AddUser(dto);
       }

        public long DubbelName(User_Model user_Model)
        {
            User_DTO dto = new User_DTO();
            dto = converter.ModelToDTO(user_Model);
            return (long)user_Context.DubbelName(dto);
        }
    //   public User_Model GetByName(User_Model user_Model)
    //   {
    //       User_DTO dto = new User_DTO();
    //       dto = converter.ModelToDTO(user_Model);
    //       return converter.DtoToModel(user_Context.GetByName(dto));
    //   }

     // public void Registrated(int id)
     // {
     //     user_Context.Registrated(id);
     // }
    }
}
