using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApplication.Domain.Models;

namespace LibraryApplication.Data
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> ListBooksAsync();

        Task<Book> GetBookByNameAsync(string name);

        Task<Book> GetBookByIdAsync(int id);

        Task<IEnumerable<Book>> ListBooksByGenreAsync(string genre);

        Task<IEnumerable<Book>> ListBooksByAuthorAsync(string author);

        Task AddBook(Book book, string genre);

        Task DeleteBookByIdAsync(int id);

        Task UpdateBook(Book book);
    }
}
