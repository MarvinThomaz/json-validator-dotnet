using DynamicValidator.JSON.Results;

namespace DynamicValidator.JSON.Types
{
    public abstract class Validation : ValidationInfo
    {
        public object Value { get; set; }

        public abstract ValidationResult Validate(string property, object source);
    }
}