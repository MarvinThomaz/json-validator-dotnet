using DynamicValidator.JSON.Extensions;
using DynamicValidator.JSON.Results;
using System;

namespace DynamicValidator.JSON.Types
{
    public class MinSizeValidation : Validation
    {
        public override ValidationResult Validate(string property, object source)
        {
            var result = source.ToNumber() < Convert.ToInt32(Value);

            return this.FromInfo(property, !result);
        }
    }
}