using DynamicValidator.JSON.Extensions;
using DynamicValidator.JSON.Results;
using System;

namespace DynamicValidator.JSON.Types
{
    public class RequiredValidation : Validation
    {
        public override ValidationResult Validate(string property, object source)
        {
            if (!Convert.ToBoolean(Value))
                return this.FromInfo(property, true);

            var result = (source.IsNumber() && source.ToNumber() == 0) || (source is string && string.IsNullOrEmpty(source.ToString())) || source == null;

            return this.FromInfo(property, !result);
        }
    }
}