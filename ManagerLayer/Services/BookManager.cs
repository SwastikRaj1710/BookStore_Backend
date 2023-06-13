using CommonLayer.Models;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class BookManager : IBookManager
    {
        private readonly IBookRepository repository;
        public BookManager(IBookRepository repository)
        {
            this.repository = repository;
        }

        public BookEntity AddBook(BookModel model)
        {
            return repository.AddBook(model);
        }

        public List<BookEntity> GetAllBooks()
        {
            return repository.GetAllBooks();
        }

        public BookEntity UpdateBook(int bookId, BookModel model)
        {
            return repository.UpdateBook(bookId, model);
        }

        public bool DeleteBook(int bookId)
        {
            return repository.DeleteBook(bookId);
        }
    }
}
