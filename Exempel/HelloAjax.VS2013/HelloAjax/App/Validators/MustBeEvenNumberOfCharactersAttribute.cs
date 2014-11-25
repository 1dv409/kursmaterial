using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HelloAjax
{
    public class MustBeEvenNumberOfCharactersAttribute : ValidationAttribute
    {
        public MustBeEvenNumberOfCharactersAttribute()
            : base("The string must contain an even number of charaters.")
        {
            // Empty!
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            return value is String && ((String)value).Length % 2 == 0;
        }
    }
}