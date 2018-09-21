using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONValidationTest.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(List<ValidationResult> validations)
        {
            Validations = validations.Select(v => new ValidationError { Code = v.Code, Message = v.Message, Property = v.Property }).ToList();
        }

        public List<ValidationError> Validations { get; }
    }
}
