using DynamicValidator.JSON.Extensions;
using DynamicValidator.JSON.Results;
using System;

namespace DynamicValidator.JSON.Types
{
    public class MinLengthValidation : Validation
    {
        public override ValidationResult Validate(string property, object source)
        {
            if (source is string)
            {
                var result = (source as string).Length < Convert.ToInt32(Value);

                return this.FromInfo(property, !result);
            }

            return this.FromInfo(property, false);
        }
    }
}