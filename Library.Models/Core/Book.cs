using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Core
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required int ReleaseYear { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
