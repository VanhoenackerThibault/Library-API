using Library.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Models.Dto
{
    public class AuthorDto
    {
        [Required]
        [MinimumLengthAfterTrim]
        public required string Name { get; set; }
    }
}
