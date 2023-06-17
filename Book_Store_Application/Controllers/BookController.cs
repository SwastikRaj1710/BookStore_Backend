using CommonLayer.Models;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Book_Store_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManager manager;

        public BookController(IBookManager manager)
        {
            this.manager = manager;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddBook(BookModel model)
        {
            try
            {
                var checkBook = manager.AddBook(model);
                if(checkBook != null)
                {
                    return Ok(new ResponseModel<BookEntity> { Status = true, Message = "Book Added Successfully", Data = checkBook });
                }
                else
                {
                    return BadRequest(new ResponseModel<BookEntity> { Status = false, Message = "Unable to add new book", Data = null });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var booksList = new List<BookEntity>();
                booksList = manager.GetAllBooks();
                if (booksList.Count > 0)
                {
                    return Ok(new ResponseModel<List<BookEntity>> { Status = true, Message = "Fetched all Books", Data = booksList });
                }
                else
                {
                    return BadRequest(new ResponseModel<List<BookEntity>> { Status = false, Message = "Unable to fetch books", Data = null });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet("{bookId}")]
        public IActionResult GetBookById(int bookId)
        {
            try
            {
                var book = new BookEntity();
                book = manager.GetBookById(bookId);
                if (book!=null)
                {
                    return Ok(new ResponseModel<BookEntity> { Status = true, Message = "Fetched the Book", Data = book });
                }
                else
                {
                    return BadRequest(new ResponseModel<BookEntity> { Status = false, Message = "Unable to fetch book details", Data = null });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{bookId}")]
        public IActionResult UpdateBook(int bookId, BookModel model)
        {
            try
            {
                var findBook = manager.UpdateBook(bookId, model);
                if (findBook != null)
                {
                    return Ok(new ResponseModel<BookEntity> { Status = true, Message = "Updated book details from db", Data = findBook });
                }
                else
                {
                    return BadRequest(new ResponseModel<BookEntity> { Status = false, Message = "Unable to update book's details from db", Data = findBook });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{bookId}")]
        public IActionResult DeleteBook(int bookId)
        {
            try
            {
                var findBook = manager.DeleteBook(bookId);
                if (findBook)
                {

                    return Ok(new ResponseModel<bool> { Status = true, Message = "Deleted book details from db", Data = findBook });
                }
                else
                {
                    return BadRequest(new ResponseModel<bool> { Status = false, Message = "Unable to fetch book's details from db", Data = findBook });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
