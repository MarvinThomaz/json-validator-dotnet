using DynamicValidator.JSON.Results;

namespace DynamicValidator.JSON.Extensions
{
    public static class ValidationInfoExtensions
    {
        public static ValidationResult FromInfo(this ValidationInfo info, string property, bool result)
        {
            return new ValidationResult(info, property, result);
        }
    }
}