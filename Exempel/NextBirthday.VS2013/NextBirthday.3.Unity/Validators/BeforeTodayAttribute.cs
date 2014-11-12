using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NextBirthdayUnity.Validators
{
    public class BeforeTodayAttribute : ValidationAttribute, IClientValidatable
    {
        public BeforeTodayAttribute()
            : base("The date must be later than todays date.")
        {
            // Empty!
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            return value is DateTime && ((DateTime)value) < DateTime.Today;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "beforetoday"
            };
        }
    }
}