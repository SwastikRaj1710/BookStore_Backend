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
                if(context.Cart.Any(x => x.BookId == bookId))
                {
                    CartEntity cart = context.Cart.FirstOrDefault(x => x.BookId == bookId);
                    CartItemModel item = new CartItemModel();
                    item.Quantity = cart.Quantity + 1;
                    UpdateQuantity(userId, bookId, item);
                    return cart;
                }
                else
                {
                    CartEntity entity = new CartEntity();
                    entity.BookId = bookId;
                    entity.UserId = userId;
                    entity.Quantity = 1;
                    var check = context.Cart.Add(entity);
                    context.SaveChanges();

                    if (check != null)
                    {
                        return entity;
                    }
                    else { return null; }
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CartEntity UpdateQuantity(int userId, int bookId, CartItemModel model)
        {
            try
            {
                var CartItemDetails = context.Cart.FirstOrDefault(x => x.UserId == userId && x.BookId == bookId);
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

        public bool DeleteItem(int userId, int bookId)
        {
            try
            {
                var CartItemDetails = context.Cart.FirstOrDefault(x => x.UserId == userId && x.BookId == bookId);
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

        public bool RemoveAllItems()
        {
            try
            {
                if(context.Cart.Count()>0)
                {
                    foreach (var item in context.Cart)
                    {
                        context.Cart.Remove(item);
                    }
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
    }
}
