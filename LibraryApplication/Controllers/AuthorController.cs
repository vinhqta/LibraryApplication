using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApplication.Domain.Models;
using LibraryApplication.Data;

namespace LibraryApplication.Controllers
{
    [Route("/api/[controller]")]
    public class AuthorController
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _authorRepository.ListAllAuthorsAsync();
        }

        [Route("/api/[controller]/name/{name}")]
        [HttpGet]
        public async Task<Author> GetAuthorByNameAsync(string name)
        {
            return await _authorRepository.GetAuthorByNameAsync(name);
        }

        [HttpPost]
        public async Task AddAuthorAsync([FromBody]Author author)
        {
            await _authorRepository.AddAuthorAsync(author);
        }
    }
}
