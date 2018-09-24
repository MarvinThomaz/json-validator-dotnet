using DynamicValidator.Abstractions;
using DynamicValidator.JSON.Types;
using System.Collections.Generic;
using System.Linq;

namespace DynamicValidator.JSON.Entities
{
    /// <summary>
    /// Classe usada para configurar as validações de uma determinada propriedade.
    /// </summary>
    public class PropertyValidator
    {
        /// <summary>
        /// Nome da propriedade
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Validação de propriedade obrigatória
        /// </summary>
        public RequiredValidation Required { get; set; }

        /// <summary>
        /// Validação de tamanho mínimo de propriedade
        /// </summary>
        public MinLengthValidation MinLength { get; set; }

        /// <summary>
        /// Validação de tamanho máximo de propriedade.
        /// </summary>
        public MaxLengthValidation MaxLength { get; set; }

        /// <summary>
        /// Validação de valor mínimo da propriedade.
        /// </summary>
        public MinSizeValidation MinSize { get; set; }

        /// <summary>
        /// Validação de valor máximo da propriedade.
        /// </summary>
        public MaxSizeValidation MaxSize { get; set; }

        /// <summary>
        /// Método usado para pegar todas as validações utilizadas em forma de lista.
        /// </summary>
        /// <returns>Listagem de validações utilizadas.</returns>
        public IEnumerable<IValidation> GetValidations()
        {
            var validations = GetType()
                .GetProperties()
                .Select(p => p?.GetValue(this))
                .Where(p => p is IValidation)
                .Cast<IValidation>();

            return validations;
        }
    }
}