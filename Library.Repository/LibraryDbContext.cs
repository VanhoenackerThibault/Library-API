using Library.Models.Core;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
