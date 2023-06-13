using CommonLayer.Models;
using Microsoft.Extensions.Logging;
using RepositoryLayer.BookStoreDBContext;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class CartRepository : ICartRepository
    {
        private readonly BookStoreContext context;
        public CartRepository(BookStoreContext context) 
        {
            this.context = context;
        }

        public CartEntity AddItem(int userId, int bookId)
        {
            try
            {
                CartEntity entity = new CartEntity();
                entity.BookId = bookId;
                entity.UserId = userId;
                entity.Quantity = 1;
                var check = context.Cart.Add(entity);
                context.SaveChanges();

                if(check!=null)
                {
                    return entity;
                }
                else { return entity; }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CartEntity UpdateQuantity(int userId, int itemId, CartItemModel model)
        {
            try
            {
                var CartItemDetails = context.Cart.FirstOrDefault(x => x.UserId == userId && x.CartItemId == itemId);
                if(CartItemDetails!=null)
                {
                    CartItemDetails.Quantity = model.Quantity;

                    context.SaveChanges();
                    return CartItemDetails;
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

        public bool DeleteItem(int userId, int itemId)
        {
            try
            {
                var CartItemDetails = context.Cart.FirstOrDefault(x => x.UserId == userId && x.CartItemId == itemId);
                if (CartItemDetails != null)
                {
                    context.Cart.Remove(CartItemDetails);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CartEntity> GetAllItems(int userId)
        {
            try
            {
                return context.Cart.Where(x => x.UserId == userId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
