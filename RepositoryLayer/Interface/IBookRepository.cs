using CommonLayer.Models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IBookRepository
    {
        public BookEntity AddBook(BookModel model);
        public List<BookEntity> GetAllBooks();
        public BookEntity GetBookById(int id);
        public BookEntity UpdateBook(int bookId, BookModel model);
        public bool DeleteBook(int bookId);
    }
}
