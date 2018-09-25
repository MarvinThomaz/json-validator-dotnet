using DynamicValidator.Abstractions;
using System;

namespace DynamicValidator.Attributes
{
    public class MaxLentghAttribute : Attribute, IMaxLengthValidation
    {
        private int _value;

        public MaxLentghAttribute(int length)
        {
            _value = length;
        }
        
        object IValidation.Value { get => _value; set => _value = Convert.ToInt32(value); }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}