using CommonLayer.Models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRepository
    {
        public UserEntity Register(UserRegModel model);
        public string Login(UserLoginModel model);
        public UserEntity UpdateDetails(int userId, CustomerDetailsModel model);
        public UserEntity GetDetails(int userId);
    }
}
