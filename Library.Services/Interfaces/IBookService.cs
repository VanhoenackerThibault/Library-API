using Library.Models.Core;
using Library.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        public Task<List<Book>> GetBooksAsync();
        public Task<Book?> GetBookByIdAsync(int id);
        public Task<Book?> CreateBookAsync(BookDto bookDto);
        public Task<Book?> UpdateBookAsync(int id, BookDto bookDto);
        public Task<bool?> DeleteBookAsync(int id);
    }
}
