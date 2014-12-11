using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeekTweet.Domain.Validation
{
    public interface IDataAnnotationValidator
    {
        bool TryValidate(object @object, out ICollection<ValidationResult> results);
    }
}
