using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
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
    public class BookRepository : IBookRepository
    {
        public readonly BookStoreContext context;

        public BookRepository(BookStoreContext context)
        {
            this.context = context;
        }

        public BookEntity AddBook(BookModel model)
        {
            try
            {
                BookEntity entity = new BookEntity();
                entity.BookName = model.BookName;
                entity.Author = model.Author;
                entity.Description = model.Description;
                entity.Quantity = model.Quantity;
                entity.Price = model.Price;
                entity.DiscountPrice = model.DiscountPrice;
                var check = context.Book.Add(entity);
                context.SaveChanges();

                if(check!=null)
                {
                    return entity;
                }
                else { return null; }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<BookEntity> GetAllBooks()
        {
            try
            {
                return context.Book.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public BookEntity UpdateBook(int bookId, BookModel model)
        {
            try
            {
                var bookDetails = context.Book.FirstOrDefault(x => x.BookId == bookId);
                if (bookDetails != null)
                {
                    bookDetails.BookName = model.BookName;
                    bookDetails.Author = model.Author;
                    bookDetails.Description = model.Description;
                    bookDetails.Quantity = model.Quantity;
                    bookDetails.Price = model.Price;
                    bookDetails.DiscountPrice = model.DiscountPrice;

                    context.SaveChanges();
                    return bookDetails;
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

        public bool DeleteBook(int bookId)
        {
            try
            {
                var bookDetails = context.Book.FirstOrDefault(x => x.BookId == bookId);
                if (bookDetails != null)
                {
                    context.Book.Remove(bookDetails);
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
