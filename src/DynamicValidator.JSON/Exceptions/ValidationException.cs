using DynamicValidator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicValidator.JSON.Exceptions
{
    /// <summary>
    /// Excessão que é utilizada no momento em que validações não passaram.
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Constrói a excessão baseada em uma lista de validações que não passaram.
        /// </summary>
        /// <param name="validations">Lista de validações.</param>
        public ValidationException(IEnumerable<ValidationResult> validations)
        {
            Validations = validations.Select(v => new ValidationError { Code = v.Code, Message = v.Message, Property = v.Property });
        }

        /// <summary>
        /// Lista de validações da excessão.
        /// </summary>
        public IEnumerable<ValidationError> Validations { get; }
    }
}
