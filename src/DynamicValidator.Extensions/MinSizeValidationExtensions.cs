using System;

namespace DynamicValidator.Abstractions
{
    public static class MinSizeValidationExtensions
    {
        public static ValidationResult Validate(this IMinSizeValidation validation, string property, object source)
        {
            var result = source.ToNumber() < Convert.ToInt32(validation.Value);

            return validation.ToResult(property, !result);
        }
    }
}