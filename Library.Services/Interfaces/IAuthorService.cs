using Library.Models.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Interfaces
{
    public interface IAuthorService
    {
        public Task<List<Author>> GetAuthorsAsync();

        public Task<Author?> GetAuthorByIdAsync(int id);
    }
}
