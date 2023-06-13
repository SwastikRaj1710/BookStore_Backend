using CommonLayer.Models;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class CartManager : ICartManager
    {
        private readonly ICartRepository repository;

        public CartManager(ICartRepository repository)
        {
            this.repository = repository;
        }

        public CartEntity AddItem(int userId, int bookId)
        {
            return repository.AddItem(userId, bookId);
        }
        public CartEntity UpdateQuantity(int userId, int itemId, CartItemModel model)
        {
            return repository.UpdateQuantity(userId, itemId, model);
        }
        public bool DeleteItem(int userId, int itemId)
        {
            return repository.DeleteItem(userId, itemId);
        }
        public List<CartEntity> GetAllItems(int userId)
        {
            return repository.GetAllItems(userId);
        }
    }
}
