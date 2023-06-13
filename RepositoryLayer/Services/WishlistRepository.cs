using RepositoryLayer.BookStoreDBContext;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly BookStoreContext context;

        public WishlistRepository(BookStoreContext context)
        {
            this.context = context;
        }

        public WishlistEntity AddItem(int userId, int bookId)
        {
            try
            {
                WishlistEntity entity = new WishlistEntity();
                entity.BookId = bookId;
                entity.UserId = userId;
                var check = context.Wishlist.Add(entity);
                context.SaveChanges();

                if (check != null)
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

        public bool DeleteItem(int userId, int itemId)
        {
            try
            {
                var WishlistItemDetails = context.Wishlist.FirstOrDefault(x => x.UserId == userId && x.WishlistItemId == itemId);
                if (WishlistItemDetails != null)
                {
                    context.Wishlist.Remove(WishlistItemDetails);
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

        public List<WishlistEntity> GetAllItems(int userId)
        {
            try
            {
                return context.Wishlist.Where(x => x.UserId == userId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
