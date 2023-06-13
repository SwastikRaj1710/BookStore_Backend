using CommonLayer.Models;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface IBookManager
    {
        public BookEntity AddBook(BookModel model);
        public List<BookEntity> GetAllBooks();
        public BookEntity UpdateBook(int bookId, BookModel model);
        public bool DeleteBook(int bookId);
    }
}
