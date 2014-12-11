using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeekTweet.Domain.Validation
{
    public class DataAnnotationsValidator : IDataAnnotationValidator
    {
        public bool TryValidate(object @object, out ICollection<ValidationResult> results)
        {
            var validationContext = new ValidationContext(@object);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(@object, validationContext, results, true);
        }
    }
}
