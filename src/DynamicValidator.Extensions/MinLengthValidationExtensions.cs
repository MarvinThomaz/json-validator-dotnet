using System;

namespace DynamicValidator.Abstractions
{
    public static class MinLengthValidationExtensions
    {
        public static ValidationResult Validate(this IMinLengthValidation validation, string property, object source)
        {
            if (source is string)
            {
                var result = source.ToString()?.Length < Convert.ToInt32(validation.Value);

                return validation.ToResult(property, !result);
            }

            return validation.ToResult(property, false);
        }
    }
}
