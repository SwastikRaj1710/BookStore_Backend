using CommonLayer.Models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface ICartManager
    {
        public CartEntity AddItem(int userId, int bookId);
        public CartEntity UpdateQuantity(int userId, int bookId, CartItemModel model);
        public bool DeleteItem(int userId, int bookId);
        public List<CartEntity> GetAllItems(int userId);
        public bool RemoveAllItems();
    }
}
