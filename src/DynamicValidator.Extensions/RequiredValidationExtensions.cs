using System;

namespace DynamicValidator.Abstractions
{
    public static class RequiredValidationExtensions
    {
        public static ValidationResult Validate(this IRequiredValidation validation, string property, object source)
        {
            var value = Convert.ToBoolean(validation.Value);

            if (!value)
                return validation.ToResult(property, true);

            var result = (source.IsNumber() && source.ToNumber() == 0) || (source is string && string.IsNullOrEmpty(source.ToString())) || source == null;

            return validation.ToResult(property, !result);
        }
    }
}