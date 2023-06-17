using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class WishlistManager : IWishlistManager
    {
        private readonly IWishlistRepository repository;

        public WishlistManager(IWishlistRepository repository)
        {
            this.repository = repository;
        }

        public WishlistEntity AddItem(int userId, int bookId)
        {
            return repository.AddItem(userId, bookId);
        }
        public bool DeleteItem(int userId, int bookId)
        {
            return repository.DeleteItem(userId, bookId);  
        }
        public List<WishlistEntity> GetAllItems(int userId)
        {
            return repository.GetAllItems(userId);
        }
    }
}
