using CommonLayer.Models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface IAdminManager
    {
        public AdminEntity Register(AdminRegModel model);
        public string Login(AdminLoginModel model);
    }
}
