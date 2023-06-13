using CommonLayer.Models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface IUserManager
    {
        public UserEntity Register(UserRegModel model);
        public string Login(UserLoginModel model);
        public UserEntity UpdateDetails(int userId, CustomerDetailsModel model);
    }
}
