using DynamicValidator.Abstractions;

namespace DynamicValidator.Abstractions
{
    public static class ValidationExtensions
    {
        public static ValidationResult Validate(this IValidation validation, string property, object source)
        {
            if (validation is IMaxLengthValidation)
                return (validation as IMaxLengthValidation).Validate(property, source);
            else if (validation is IMinLengthValidation)
                return (validation as IMinLengthValidation).Validate(property, source);
            else if (validation is IMaxSizeValidation)
                return (validation as IMaxSizeValidation).Validate(property, source);
            else if (validation is IMinSizeValidation)
                return (validation as IMinSizeValidation).Validate(property, source);
            else
                return (validation as IRequiredValidation).Validate(property, source);
        }
    }
}