using CommonLayer.Models;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using RepositoryLayer.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Book_Store_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager manager;

        public CartController(ICartManager manager)
        {
            this.manager = manager;
        }

        [Authorize(Roles = "User")]
        [HttpPost("{bookId}")]
        public IActionResult AddToCart(int bookId)
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var checkCart = manager.AddItem(userId, bookId);
                if (checkCart != null)
                {
                    return Ok(new ResponseModel<CartEntity> { Status = true, Message = "Item Added to Cart Successfully", Data = checkCart });
                }
                else
                {
                    return BadRequest(new ResponseModel<CartEntity> { Status = false, Message = "Unable to add new item to cart", Data = null });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Authorize(Roles = "User")]
        [HttpPut("{bookId}")]
        public IActionResult UpdateQuantity(int bookId, CartItemModel model)
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var findCartItem = manager.UpdateQuantity(userId, bookId, model);
                if (findCartItem != null)
                {
                    return Ok(new ResponseModel<CartEntity> { Status = true, Message = "Updated cart item details from db", Data = findCartItem });
                }
                else
                {
                    return BadRequest(new ResponseModel<CartEntity> { Status = false, Message = "Unable to update cart item's details from db", Data = findCartItem });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize(Roles = "User")]
        [HttpDelete("{bookId}")]
        public IActionResult RemoveFromCart(int bookId)
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var findCartItem = manager.DeleteItem(userId, bookId);
                if (findCartItem)
                {

                    return Ok(new ResponseModel<bool> { Status = true, Message = "Removed item from the cart", Data = findCartItem });
                }
                else
                {
                    return BadRequest(new ResponseModel<bool> { Status = false, Message = "Unable to remove item from cart", Data = findCartItem });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult GetAllItems()
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var cart = new List<CartEntity>();
                cart = manager.GetAllItems(userId);
                if (cart.Count != 0)
                {
                    return Ok(new ResponseModel<List<CartEntity>> { Status = true, Message = "Fetched all Items from the cart", Data = cart });
                }
                else
                {
                    return BadRequest(new ResponseModel<List<CartEntity>> { Status = false, Message = "Unable to fetch items from cart", Data = null });
                }                
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpDelete]
        public IActionResult GetItems()
        {
            try
            {
                var deleteResult = manager.RemoveAllItems();
                if (deleteResult)
                {
                    return Ok(new ResponseModel<bool> { Status=true, Message="Cart Emptied successfully", Data=deleteResult });
                }
                else
                {
                    return BadRequest(new ResponseModel<bool> { Status = false, Message = "Cart Empty unsuccessful", Data = deleteResult });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
