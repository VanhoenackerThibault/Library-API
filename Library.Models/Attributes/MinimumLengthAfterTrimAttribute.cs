using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Models.Attributes
{
    public class MinimumLengthAfterTrimAttribute : ValidationAttribute
    {
        public int MinLength { get; set; }

        public int MaxLength { get; set; }

        public MinimumLengthAfterTrimAttribute(int minLength = 3, int maxLength = 100)
        {
            MinLength = minLength;
            MaxLength = maxLength;
        }
        public override bool IsValid(object? value)
        {
            if (value == null) { return false; }

            string properyString = (string) value;

            if (properyString is null)
            {
                return false;
            }

            string trimedString = properyString.Trim();

            if (trimedString.Length < MinLength || trimedString.Length > MaxLength)
            {
                return false;
            }

            return true;
        }
    }
}
