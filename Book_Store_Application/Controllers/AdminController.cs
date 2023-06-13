using CommonLayer.Models;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;

namespace Book_Store_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminManager manager;
        public AdminController(IAdminManager manager)
        {
            this.manager = manager;
        }

        [HttpPost("Register")]
        public IActionResult UserRegister(AdminRegModel model)
        {
            try
            {
                var checkReg = manager.Register(model);
                if (checkReg != null)
                {
                    return Ok(new ResponseModel<AdminEntity> { Status = true, Message = "Register Successful", Data = checkReg });
                }
                else
                {
                    return BadRequest(new ResponseModel<AdminEntity> { Status = false, Message = "Register Unsuccessful", Data = checkReg });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(AdminLoginModel login)
        {
            try
            {
                var checkLogin = manager.Login(login);
                if (checkLogin != null)
                {
                    return Ok(new ResponseModel<string> { Status = true, Message = "Login Successful", Data = checkLogin });
                }
                else
                {
                    return BadRequest(new ResponseModel<string> { Status = false, Message = "Login Unsuccessful", Data = checkLogin });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
