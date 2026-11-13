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
        public Task<Book?> UpdateBook(int id, BookDto bookDto);
        public Task DeleteBookAsync(int id);
    }
}
