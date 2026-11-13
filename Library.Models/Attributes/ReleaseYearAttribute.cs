using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Models.Attributes
{
    public class ReleaseYearAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            // try to parse value to int32
            int? releaseYear = (int) value;

            if (releaseYear < 1)
            {
                return false;
            }

            if (releaseYear > DateTime.UtcNow.Year)
            {
                return false;
            }

            // release year is not smaller than 1 and is not in the future
            return true;
        }
    }
}
