using CommonLayer.Models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICartRepository
    {
        public CartEntity AddItem(int userId, int bookId);
        public CartEntity UpdateQuantity(int userId, int itemId, CartItemModel model);
        public bool DeleteItem(int userId, int itemId);
        public List<CartEntity> GetAllItems(int userId);
    }
}
