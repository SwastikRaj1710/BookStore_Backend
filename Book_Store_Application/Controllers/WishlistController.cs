using CommonLayer.Models;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using System;

namespace Book_Store_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistManager manager;
        public WishlistController(IWishlistManager manager)
        {
            this.manager = manager;
        }

        [Authorize(Roles = "User")]
        [HttpPost("{bookId}")]
        public IActionResult AddToWishlist(int bookId)
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var checkWishlist = manager.AddItem(userId, bookId);
                if (checkWishlist != null)
                {
                    return Ok(new ResponseModel<WishlistEntity> { Status = true, Message = "Item Added to Wishlist Successfully", Data = checkWishlist });
                }
                else
                {
                    return BadRequest(new ResponseModel<WishlistEntity> { Status = false, Message = "Unable to add new item to wishlist", Data = null });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize(Roles = "User")]
        [HttpDelete("{wishlistItemId}")]
        public IActionResult RemoveFromWishlist(int wishlistItemId)
        {
            try
            {
                var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var findWishlistItem = manager.DeleteItem(userId, wishlistItemId);
                if (findWishlistItem)
                {

                    return Ok(new ResponseModel<bool> { Status = true, Message = "Removed item from the wishlist", Data = findWishlistItem });
                }
                else
                {
                    return BadRequest(new ResponseModel<bool> { Status = false, Message = "Unable to remove item from wishlist", Data = findWishlistItem });
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
                var wishlist = new List<WishlistEntity>();
                wishlist = manager.GetAllItems(userId);
                if (wishlist.Count != 0)
                {
                    return Ok(new ResponseModel<List<WishlistEntity>> { Status = true, Message = "Fetched all Items from the wishlist", Data = wishlist });
                }
                else
                {
                    return BadRequest(new ResponseModel<List<WishlistEntity>> { Status = false, Message = "Unable to fetch items from wishlist", Data = null });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
