using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApplication.Data;
using LibraryApplication.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Services
{


    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _libraryContext;

        public BookRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task AddBook(Book book, string genre)
        {
            await _libraryContext.Books.AddAsync(book);
            Genre genreEntry = new Genre();
            genreEntry.Name = genre;
            await _libraryContext.Genre.AddAsync(genreEntry);

            _libraryContext.SaveChanges();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _libraryContext.Books.FindAsync(id);
        }

        public async Task<Book> GetBookByNameAsync(string name)
        {
            return await _libraryContext.Books.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Book>> ListBooksAsync()
        {
            return await _libraryContext.Books.ToListAsync();
        }

        public async Task DeleteBookByIdAsync(int id)
        {
            var book = await _libraryContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            _libraryContext.Books.Remove(book);
            await _libraryContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Book>> ListBooksByAuthorAsync(string author)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> GetBookByNameAndLocation(string name, string location)
        {
            return await _libraryContext.Books.Where(x => x.Name == name && x.Location == location).FirstOrDefaultAsync();
        }

        public async Task UpdateBook(Book book)
        {
            var update = await _libraryContext.Books.Where(x => x.Name == book.Name).FirstOrDefaultAsync();

            update.Name = book.Name;
            update.Location = book.Location;
            update.DatePublished = book.DatePublished;

            _libraryContext.Books.Update(update);

            await _libraryContext.SaveChangesAsync();
        }

        public Task<IEnumerable<Book>> ListBooksByGenreAsync(string genre)
        {
            throw new NotImplementedException();
        }
    }
}
