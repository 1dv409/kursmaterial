using System;
using System.ComponentModel.DataAnnotations;

namespace NextBirthday.Infrastructure
{
    public class BeforeTodayAttribute : ValidationAttribute
    {
        public BeforeTodayAttribute()
            : base("The date must be earlier than todays date.")
        {
            // Empty!
        }

        public override bool IsValid(object value)
        {
            return base.IsValid(value) && ((DateTime)value) < DateTime.Today;
        }
    }
}