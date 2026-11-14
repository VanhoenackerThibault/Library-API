using Library.Models.Core;
using Library.Models.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Mappers
{
    public static class PagedResponseMapper
    {
        public static PagedResponse<Book> ToPagedResponse(this List<Book> books, int pageSize, int currentPage)
        {
            int totalBooks = books.Count;
            List<Book> result = books.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResponse<Book>
            {
                TotalObjects = totalBooks,
                Result = result,
                CurrentPage = totalBooks / pageSize,
                TotalPages = totalBooks
            };
        }

        public static PagedResponse<Author> ToPagedResponse(this List<Author> authors, int pageSize, int currentPage)
        {
            int totalAuthors = authors.Count;
            List<Author> result = authors.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResponse<Author>
            {
                TotalObjects = totalAuthors,
                Result = result,
                CurrentPage = totalAuthors / pageSize,
                TotalPages = totalAuthors
            };
        }
    }
}
