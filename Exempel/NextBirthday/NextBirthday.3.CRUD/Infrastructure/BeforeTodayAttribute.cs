using System;
using System.ComponentModel.DataAnnotations;

namespace NextBirthday.Infrastructure
{
    public class BeforeTodayAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value) && ((DateTime)value) < DateTime.Today;
        }
    }
}