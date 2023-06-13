using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IWishlistRepository
    {
        public WishlistEntity AddItem(int userId, int bookId);
        public bool DeleteItem(int userId, int itemId);
        public List<WishlistEntity> GetAllItems(int userId);

    }
}
