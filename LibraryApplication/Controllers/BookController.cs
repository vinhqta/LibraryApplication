using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApplication.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryApplication.Data;

namespace LibraryApplication.Controllers
{
    [Route("/api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        //private readonly ILoggerService _logger; 

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            //_logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            //try
            //{
            //    var books = await _bookService.ListBooksAsync();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Data); // Use logger, not sure how
            //}

            //return BadRequest();

            var books = await _bookRepository.ListBooksAsync();
            return books;
        }

        [Route("/api/[controller]/{id}")]
        [HttpGet]
        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            return book;
        }

        [Route("/api/[controller]/name/{name}")]
        [HttpGet]
        public async Task<Book> GetBookByNameAsync(string name)
        {
            var book = await _bookRepository.GetBookByNameAsync(name);
            return book;
        }

        [Route("/api/[controller]/add/{genre}")]
        [HttpPost]
        public async Task<ActionResult> AddBookAsync([FromBody]Book book, string genre)
        {
            await _bookRepository.AddBook(book, genre);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBookAsync([FromBody]Book book)
        {
            await _bookRepository.UpdateBook(book);
            return Ok();
        }

        [HttpDelete]
        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteBookByIdAsync(id);
        }


    }
}
