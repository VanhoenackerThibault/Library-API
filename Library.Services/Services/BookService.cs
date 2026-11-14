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
            return await dbContext.Books.Include(b => b.Author).AsNoTracking().ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await dbContext.Books.Include(b => b.Author).AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book?> CreateBookAsync(BookDto bookDto)
        {
            Author? author = await dbContext.Authors.AsNoTracking().FirstOrDefaultAsync(o => o.Id == bookDto.AuthorId);

            if (author is null)
            {
                return null;
            }

            EntityEntry<Book> newBook = dbContext.Books.Add(bookDto.ToEntity());

            await dbContext.SaveChangesAsync();

            return newBook.Entity;
        }

        public async Task<Book?> UpdateBookAsync(int id, BookDto bookDto)
        {
            Book? dbBook = await dbContext.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);

            if (dbBook is null)
            {
                return null;
            }

            Author? author = await dbContext.Authors.AsNoTracking().FirstOrDefaultAsync(o => o.Id == bookDto.AuthorId);

            if (author is null)
            {
                return null;
            }

            dbBook.AuthorId = bookDto.AuthorId;
            dbBook.ReleaseYear = bookDto.ReleaseYear;
            dbBook.Title = bookDto.Title;

            await dbContext.SaveChangesAsync();

            return dbBook;
        }

        public async Task<bool?> DeleteBookAsync(int id)
        {
            Book? dbBook = await dbContext.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);

            if (dbBook is null)
            {
                return null;
            }

            dbContext.Books.Remove(dbBook);

            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
