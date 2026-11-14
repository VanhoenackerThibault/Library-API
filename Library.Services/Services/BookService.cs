using Library.Models.Core;
using Library.Models.Dto;
using Library.Models.Mappers;
using Library.Repository;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Services
{
    public class BookService(LibraryDbContext dbContext) : IBookService
    {
        public async Task<List<Book>> GetBooksAsync()
        {
            return await dbContext.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await dbContext.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> CreateBookAsync(BookDto bookDto)
        {
            EntityEntry<Book> newBook = dbContext.Books.Add(bookDto.ToEntity());

            await dbContext.SaveChangesAsync();

            return newBook.Entity;
        }

        public async Task<Book> UpdateBookAsync(int id, BookDto bookDto)
        {
            Book? dbBook = await dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (dbBook is null)
            {
                throw new ArgumentException("Given id does not have a book");
            }

            dbBook.AuthorId = bookDto.AuthorId;
            dbBook.ReleaseYear = bookDto.ReleaseYear;
            dbBook.Title = bookDto.Title;

            await dbContext.SaveChangesAsync();

            return dbBook;
        }

        public async Task DeleteBookAsync(int id)
        {
            Book? dbBook = await dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);

            if (dbBook is null)
            {
                throw new ArgumentException("Given id does not have a book");
            }

            dbContext.Books.Remove(dbBook);

            await dbContext.SaveChangesAsync();
        }
    }
}
