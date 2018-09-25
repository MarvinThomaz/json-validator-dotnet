using DynamicValidator.Abstractions;
using System;

namespace DynamicValidator.Attributes
{
    public class MinLengthAttribute : Attribute, IMinLengthValidation
    {
        private int _length;

        public MinLengthAttribute(int length)
        {
            _length = length;
        }
        
        object IValidation.Value { get => _length; set => _length = Convert.ToInt32(value); }
        public int Code { get; set; }
        public string Message { get; set; }
    }
}