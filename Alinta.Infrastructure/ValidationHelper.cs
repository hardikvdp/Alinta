using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alinta.Infrastructure
{
    public static class ValidationHelper
    {
        public static IEnumerable<ValidationResult> Validate(this object toValidate)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(toValidate, null, null);
            Validator.TryValidateObject(toValidate, context, results, true);
            return results;
        }
    }
}
