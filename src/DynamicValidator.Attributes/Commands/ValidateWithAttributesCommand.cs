using DynamicValidator.Abstractions;
using DynamicValidator.Exceptions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DynamicValidator.Attributes.Commands
{
    public class ValidateWithAttributesCommand : IValidateCommand
    {
        public void Execute(object obj)
        {
            var type = obj.GetType();
            var errors = new List<ValidationResult>();

            ExecuteValidationInAllProperties(obj, type, errors);

            if (errors.Count > 0)
                throw new ValidationException(errors);
        }

        private static void ExecuteValidationInAllProperties(object obj, Type type, List<ValidationResult> errors, string parentName = null)
        {
            foreach (var property in type.GetProperties())
            {
                var value = property.GetValue(obj);

                if (value != null && !property.PropertyType.IsValueType && !property.PropertyType.IsPrimitive && !property.PropertyType.Equals(typeof(string)))
                {
                    ExecuteValidationInAllProperties(value, property.PropertyType, errors, property.Name);
                }

                ExecuteValidationByAttributeInProperty(obj, errors, property, parentName);
            }
        }

        private static void ExecuteValidationByAttributeInProperty(object obj, List<ValidationResult> errors, System.Reflection.PropertyInfo property, string parentName)
        {
            var attributes = property.GetCustomAttributes(typeof(IValidation), true) as IValidation[];

            foreach (var attribute in attributes)
            {
                ValidatePropertyByAttribute(obj, errors, property, attribute, parentName);
            }
        }

        private static void ValidatePropertyByAttribute(object obj, List<ValidationResult> errors, PropertyInfo property, IValidation attribute, string parentName)
        {
            var result = attribute.Validate(parentName == null ? property.Name : $"{parentName}.{property.Name}", property.GetValue(obj));

            if (!result.Result)
                errors.Add(result);
        }
    }
}
