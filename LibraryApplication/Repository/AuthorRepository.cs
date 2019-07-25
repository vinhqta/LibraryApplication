using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApplication.Data;
using LibraryApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApplication.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _libraryContext;
        public AuthorRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task AddAuthorAsync(Author author)
        {
            await _libraryContext.Authors.AddAsync(author);
            _libraryContext.SaveChanges();
        }

        public async Task<Author> GetAuthorByNameAsync(string name)
        {
            return await _libraryContext.Authors.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Author>> ListAllAuthorsAsync()
        {
            return await _libraryContext.Authors.ToListAsync();
        }
    }
}
