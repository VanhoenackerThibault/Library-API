using Library.Models.Core;
using Library.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Mappers
{
    public static class BookMapper
    {
        public static BookDto ToDto(this Book book)
        {
            return new BookDto
            {
                AuthorId = book.AuthorId,
                ReleaseYear = book.ReleaseYear,
                Title = book.Title
            };
        }

        public static Book ToEntity(this BookDto book)
        {
            return new Book
            {
                AuthorId = book.AuthorId,
                ReleaseYear = book.ReleaseYear,
                Title = book.Title
            };
        }
    }
}
