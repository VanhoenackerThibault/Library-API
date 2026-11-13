using Library.Models.Core;
using Library.Repository;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Services
{
    public class AuthorService(LibraryDbContext dbContext) : IAuthorService
    {
        public async Task<List<Author>> GetAuthorsAsync()
        {
            return await dbContext.Authors.AsNoTracking().ToListAsync();
        }

        public async Task<Author?> GetAuthorByIdAsync(int id)
        {
            return await dbContext.Authors.AsNoTracking().FirstOrDefaultAsync(o => o.Id == id);
        }

    }
}
