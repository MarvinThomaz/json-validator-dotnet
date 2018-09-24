using DynamicValidator.JSON.Entities;
using DynamicValidator.JSON.Exceptions;
using DynamicValidator.JSON.Results;
using DynamicValidator.JSON.Types;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace DynamicValidator.JSON.Services
{
    public class ValidatorApplicationService : IValidatorApplicationService
    {
        private readonly IConfiguration _configuration;

        public ValidatorApplicationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Validate<T>(T obj)
        {
            var validations = _configuration.GetSection("Classes").Get<List<ClassValidator>>();
            var validation = validations.FirstOrDefault(v => v.Name == typeof(T).Name);
            var errors = new List<ValidationResult>();

            if (validation != null)
            {
                ValidateAllProperties(errors, validation.Properties, obj);
            }
            
            if (errors?.Count() > 0)
                throw new ValidationException(errors);
        }

        private void ValidateAllProperties<T>(List<ValidationResult> errors, List<PropertyValidator> properties, T obj)
        {
            foreach (var property in properties)
            {
                ValidateProperty(errors, property, obj);
            }
        }

        private void ValidateProperty<T>(List<ValidationResult> errors, PropertyValidator property, T obj)
        {
            var objProperty = typeof(T).GetProperty(property.Name);
            var value = objProperty.GetValue(obj);

            ValidateAll(property.Name, errors, value, property.Required, property.MaxLength, property.MinLength, property.MaxSize, property.MinSize);
        }

        private void ValidateAll(string property, List<ValidationResult> errors, object value, params Validation[] validations)
        {
            foreach (var validation in validations)
            {
                Validate(property, errors, validation, value);
            }
        }

        private void Validate(string property, List<ValidationResult> errors, Validation validation, object value)
        {
            var result = validation?.Validate(property, value);

            if (result?.Result == false)
                errors.Add(result);
        }
    }
}