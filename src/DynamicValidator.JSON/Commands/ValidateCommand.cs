using DynamicValidator.JSON.Entities;
using DynamicValidator.JSON.Exceptions;
using DynamicValidator.JSON.Results;
using DynamicValidator.JSON.Types;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace DynamicValidator.JSON.Commands
{
    public class ValidateCommand : IValidateCommand
    {
        private const string ClassValidatorSectionName = "Classes";

        private readonly List<ClassValidator> _validations;
        private List<ValidationResult> _errors;

        public ValidateCommand(IConfiguration configuration)
        {
            _validations = configuration.GetSection(ClassValidatorSectionName)
                .Get<List<ClassValidator>>(); ;
        }

        public void Execute(object obj)
        {
            _errors = new List<ValidationResult>();

            ValidatePropertiesOfType(obj);
        }

        private void ValidatePropertiesOfType(object obj, string parentProperty = null)
        {
            var validation = _validations.FirstOrDefault(v => v.Name == obj?.GetType()?.Name);

            if (validation != null)
            {
                if (parentProperty != null)
                {
                    validation.Properties.ForEach(p => p.Name = $"{parentProperty}.{p.Name}");
                }

                ValidateAllPropertiesFromObject(validation.Properties, obj);
            }

            if (_errors?.Count() > 0)
            {
                throw new ValidationException(_errors);
            }
        }

        private void ValidateAllPropertiesFromObject(List<PropertyValidator> properties, object obj)
        {
            foreach (var property in properties)
            {
                ValidatePropertyValueFromObject(property, obj);
            }
        }

        private void ValidatePropertyValueFromObject(PropertyValidator property, object obj)
        {
            var propertyName = property.Name.Split('.').Last();
            var objProperty = obj.GetType().GetProperty(propertyName);
            var value = objProperty.GetValue(obj);

            if (_validations?.Any(v => v.Name == propertyName) == true && value != null)
            {
                ValidatePropertiesOfType(value, property.Name);
            }

            ExecuteAllValidationsInProperty(property, value);
        }

        private void ExecuteAllValidationsInProperty(PropertyValidator property, object value)
        {
            foreach (var validation in property.GetValidations())
            {
                ExecuteValidationInProperty(property.Name, validation, value);
            }
        }

        private void ExecuteValidationInProperty(string property, Validation validation, object value)
        {
            var result = validation.Validate(property, value);

            if (!result.Result)
            {
                _errors.Add(result);
            }
        }
    }
}