using DynamicValidator.Abstractions;
using System;

namespace DynamicValidator.Attributes
{
    public class MaxSizeAttribute : Attribute, IMaxSizeValidation
    {
        private int _length;

        public MaxSizeAttribute(int length)
        {
            _length = length;
        }
        
        object IValidation.Value { get => _length; set => Convert.ToInt32(value); }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}