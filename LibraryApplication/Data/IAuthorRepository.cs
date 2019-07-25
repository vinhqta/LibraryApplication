using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApplication.Domain.Models;

namespace LibraryApplication.Data
{
    public interface IAuthorRepository
    {
        Task AddAuthorAsync(Author author);

        Task<Author> GetAuthorByNameAsync(string name);

        Task<IEnumerable<Author>> ListAllAuthorsAsync();

    }
}
