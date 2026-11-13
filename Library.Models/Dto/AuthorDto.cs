using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Models.Dto
{
    public class AuthorDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name cant be longer than 100 charatcers")]
        public required string Name { get; set; }
    }
}
