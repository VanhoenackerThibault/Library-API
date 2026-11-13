using Library.Models.Core;
using Library.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Mappers
{
    public static class AuthorMapper
    {
        public static AuthorDto ToDto(this Author author)
        {
            return new AuthorDto
            {
                Name = author.Name,
            };
        }

        public static Author ToEntity(this AuthorDto author)
        {
            return new Author
            {
                Name = author.Name
            };
        }
    }
}
