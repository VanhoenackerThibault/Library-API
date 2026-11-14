using Library.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Models.Dto
{
    public class BookDto
    {
        [MinimumLengthAfterTrim(MaxLength = 200, ErrorMessage = "Title cant be longer than 200 charatcers")]
        [Required]
        public required string Title { get; set; }

        [ReleaseYear(ErrorMessage = "The release year of the book cant be set to the future or has to be older than year 1")]
        [Required]
        public required int ReleaseYear { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}
