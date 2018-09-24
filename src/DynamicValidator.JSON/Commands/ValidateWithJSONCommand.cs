using DynamicValidator.Abstractions;
using DynamicValidator.JSON.Entities;
using DynamicValidator.JSON.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace DynamicValidator.JSON.Commands
{
    /// <summary>
    /// Classe utilizada para validar o objeto baseado em um JSON que traz todos os parametros para configuração.
    /// </summary>
    public class ValidateWithJSONCommand : IValidateCommand
    {
        private const string ClassValidatorSectionName = "Classes";

        private readonly List<ClassValidator> _validations;
        private List<ValidationResult> _errors;

        /// <summary>
        /// Constrói a classe solicitando o configuration da microsoft para buscar o JSON deserializado.
        /// </summary>
        /// <param name="configuration">Classe de configuração padrão Microsoft.</param>
        public ValidateWithJSONCommand(IConfiguration configuration)
        {
            _validations = configuration.GetSection(ClassValidatorSectionName)
                .Get<List<ClassValidator>>(); ;
        }

        /// <summary>
        /// Executa as validações no objeto.
        /// </summary>
        /// <param name="obj">Objeto que será validado</param>
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

        private void ExecuteValidationInProperty(string property, IValidation validation, object value)
        {
            var result = validation.Validate(property, value);

            if (!result.Result)
            {
                _errors.Add(result);
            }
        }
    }
}