using DynamicValidator.JSON.Types;
using System.Collections.Generic;
using System.Linq;

namespace DynamicValidator.JSON.Entities
{
    public class PropertyValidator
    {
        public string Name { get; set; }
        public RequiredValidation Required { get; set; }
        public MinLengthValidation MinLength { get; set; }
        public MaxLengthValidation MaxLength { get; set; }
        public MinSizeValidation MinSize { get; set; }
        public MaxSizeValidation MaxSize { get; set; }

        public IEnumerable<Validation> GetValidations()
        {
            var validations = GetType()
                .GetProperties()
                .Where(p => p.GetValue(this) is Validation)
                .Select(p => p.GetValue(this))
                .Cast<Validation>();

            return validations;
        }
    }
}