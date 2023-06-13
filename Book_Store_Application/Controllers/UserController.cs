using CommonLayer.Models;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;
using System.Security.Claims;

namespace Book_Store_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;
        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }

        [HttpPost("Register")]
        public IActionResult UserRegister(UserRegModel model)
        {
            try
            {
                var checkReg = manager.Register(model);
                if (checkReg != null)
                {
                    return Ok(new ResponseModel<UserEntity> { Status = true, Message = "Register Successful", Data = checkReg });
                }
                else
                {
                    return BadRequest(new ResponseModel<UserEntity> { Status = false, Message = "Register Unsuccessful", Data = checkReg });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLoginModel login)
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

        [Authorize(Roles = "User")]
        [HttpPut]
        public IActionResult UpdateAddressDetails(CustomerDetailsModel model)
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var findUser = manager.UpdateDetails(userId, model);
                if (findUser != null)
                {
                    return Ok(new ResponseModel<UserEntity> { Status = true, Message = "Updated user address details from db", Data = findUser });
                }
                else
                {
                    return BadRequest(new ResponseModel<UserEntity> { Status = false, Message = "Unable to update user's address details from db", Data = findUser });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
