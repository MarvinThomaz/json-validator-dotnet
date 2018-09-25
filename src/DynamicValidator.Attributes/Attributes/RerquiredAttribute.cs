using DynamicValidator.Abstractions;
using System;

namespace DynamicValidator.Attributes
{
    public class RerquiredAttribute : Attribute, IRequiredValidation
    {
        private bool _value;

        public RerquiredAttribute(bool value = true)
        {
            _value = value;
        }

        object IValidation.Value { get => _value; set => _value = Convert.ToBoolean(value); }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
