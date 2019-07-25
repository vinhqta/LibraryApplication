using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryApplication.Domain.Models;

namespace LibraryApplication.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<BookGenre> BookGenre { get; set; }
    }
}
