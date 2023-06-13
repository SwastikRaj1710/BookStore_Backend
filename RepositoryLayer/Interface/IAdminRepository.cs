using CommonLayer.Models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IAdminRepository
    {
        public AdminEntity Register(AdminRegModel model);
        public string Login(AdminLoginModel model);
    }
}
