using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.BookStoreDBContext;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace RepositoryLayer.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly BookStoreContext context;
        private readonly IConfiguration config;

        public UserRepository(BookStoreContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;
        }

        public UserEntity Register(UserRegModel model)
        {
            try
            {
                if (context.User.Any(x => x.Email == model.Email))
                {
                    throw new InvalidInputException(InvalidInputException.ExceptionType.ENTERED_DUPLICATE_ADMIN, "The entered email id already exists, please login using the same.");
                }

                string email = @"^[a-z0-9](\.?[a-z0-9]){5,}@gmail\.com$";
                Regex emailregex = new Regex(email);
                if (emailregex.IsMatch(model.Email))
                {
                    UserEntity entity = new UserEntity();
                    entity.FullName = model.FullName;
                    entity.Email = model.Email;
                    entity.Password = EncryptPassword(model.Password);
                    entity.Phone = model.Phone;
                    var check = context.User.Add(entity);
                    context.SaveChanges();
                    if (check != null)
                    {
                        return entity;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    throw new InvalidInputException(InvalidInputException.ExceptionType.ENTERED_INVALID_EMAIL,
                        "Entered Email id is either incorrect or it does not belong to the Gmail domain");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string EncryptPassword(string password)
        {
            try
            {
                var PlainPassword = Encoding.UTF8.GetBytes(password);
                var encodedPassword = Convert.ToBase64String(PlainPassword);
                return encodedPassword;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Login(UserLoginModel model)
        {
            try
            {
                var CheckDetails = context.User.FirstOrDefault(v => v.Email == model.Email && v.Password == EncryptPassword(model.Password));
                if (CheckDetails != null)
                {
                    string token = GenerateToken(CheckDetails.Email, CheckDetails.UserId, "User");
                    return token;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GenerateToken(string email, int id, string role)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                new Claim(ClaimTypes.Email,email),
                new Claim(ClaimTypes.NameIdentifier,id.ToString()),
                new Claim(ClaimTypes.Role,role),
                };
                var token = new JwtSecurityToken(
                    issuer: config["Jwt:Issuer"],
                    audience: config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: credentials
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public UserEntity UpdateDetails(int userId, CustomerDetailsModel model)
        {
            try
            {
                var userDetails = context.User.FirstOrDefault(x => x.UserId == userId);
                if (userDetails != null)
                {
                    userDetails.AddressType = model.AddressType;
                    userDetails.FullAddress = model.FullAddress;
                    userDetails.City = model.City;
                    userDetails.State = model.State;

                    context.SaveChanges();
                    return userDetails;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserEntity GetDetails(int userId)
        {
            try
            {
                return context.User.FirstOrDefault(x => x.UserId == userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
