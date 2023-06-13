using CommonLayer.Models;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository repository;

        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        public UserEntity Register(UserRegModel model)
        {
            return repository.Register(model);
        }
        public string Login(UserLoginModel model)
        {
            return repository.Login(model);
        }
        public UserEntity UpdateDetails(int userId, CustomerDetailsModel model)
        {
            return repository.UpdateDetails(userId, model);
        }
    }
}
