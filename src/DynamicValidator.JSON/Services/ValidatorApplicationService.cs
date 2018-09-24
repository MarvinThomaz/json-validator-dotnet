using DynamicValidator.JSON.Entities;
using DynamicValidator.JSON.Exceptions;
using DynamicValidator.JSON.Results;
using DynamicValidator.JSON.Types;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicValidator.JSON.Services
{
    public class ValidatorApplicationService : IValidatorApplicationService
    {
        private readonly List<ClassValidator> _validations;

        public ValidatorApplicationService(IConfiguration configuration)
        {
            _validations = configuration.GetSection("Classes").Get<List<ClassValidator>>(); ;
        }

        public void Validate<T>(T obj)
        {
            var errors = new List<ValidationResult>();

            Validate(typeof(T), obj, errors);
        }

        private void Validate(Type type, object obj, List<ValidationResult> errors)
        {
            var validation = _validations.FirstOrDefault(v => v.Name == type.Name);

            if (validation != null)
            {
                ValidateAllProperties(errors, validation.Properties, obj);
            }

            if (errors?.Count() > 0)
                throw new ValidationException(errors);
        }

        private void ValidateAllProperties(List<ValidationResult> errors, List<PropertyValidator> properties, object obj)
        {
            foreach (var property in properties)
            {
                ValidateProperty(errors, property, obj);
            }
        }

        private void ValidateProperty(List<ValidationResult> errors, PropertyValidator property, object obj)
        {
            var objProperty = obj.GetType().GetProperty(property.Name);
            var value = objProperty.GetValue(obj);

            if (_validations?.Any(v => v.Name == property.Name) == true)
            {
                ValidateAll(property.Name, errors, value, property.Required, property.MaxLength, property.MinLength, property.MaxSize, property.MinSize);
                Validate(value.GetType(), value, errors);
            }
            else
            {
                ValidateAll(property.Name, errors, value, property.Required, property.MaxLength, property.MinLength, property.MaxSize, property.MinSize);
            }
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