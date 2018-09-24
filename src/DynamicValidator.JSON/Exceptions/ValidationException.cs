using DynamicValidator.JSON.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicValidator.JSON.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationResult> validations)
        {
            Validations = validations.Select(v => new ValidationError { Code = v.Code, Message = v.Message, Property = v.Property }).ToList();
        }

        public List<ValidationError> Validations { get; }
    }
}
