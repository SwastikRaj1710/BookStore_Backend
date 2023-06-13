using CommonLayer.Models;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class AdminManager : IAdminManager
    {
        private readonly IAdminRepository repository;

        public AdminManager(IAdminRepository repository)
        {
            this.repository = repository;
        }

        public AdminEntity Register(AdminRegModel model)
        {
            return repository.Register(model);
        }

        public string Login(AdminLoginModel model)
        {
            return repository.Login(model);
        }
    }
}
