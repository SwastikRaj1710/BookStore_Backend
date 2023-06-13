using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.BookStoreDBContext
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<AdminEntity> Admin { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<BookEntity> Book { get; set; }
        public DbSet<CartEntity> Cart { get; set; }
        public DbSet<WishlistEntity> Wishlist { get; set; }
    }
}
