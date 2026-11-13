using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Models.Attributes
{
    public class MinimumLengthAfterTrim : ValidationAttribute
    {
        public bool IsValid(object? value, int MinLength = 3, int MaxLength = 100)
        {
            if (value == null) { return false; }

            string properyString = (string) value;

            if (properyString is null)
            {
                return false;
            }

            string trimedString = "";
        }
    }
}
