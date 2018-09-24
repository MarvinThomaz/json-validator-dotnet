using DynamicValidator.Abstractions;
using System;

namespace DynamicValidator.JSON.Types
{
    /// <summary>
    /// Classe que realiza validação de propriedade obrigatória.
    /// </summary>
    public class RequiredValidation : IValidation
    {
        private bool _value;

        /// <summary>
        /// Valor que define se a propriedade será obrigatória.
        /// </summary>
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = Convert.ToBoolean(value);
            }
        }

        /// <summary>
        /// Código de erro caso a propriedade não atenda a validação.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Mensagem de erro caso a propriedade não atenda a validação.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Metódo que valida a propriedade.
        /// </summary>
        /// <param name="property">Propriedade a ser validada.</param>
        /// <param name="source">Objeto onde o valor da propriedade será resgatado</param>
        /// <returns>Resultado da validação</returns>
        public ValidationResult Validate(string property, object source)
        {
            if (!_value)
                return this.ToResult(property, true);

            var result = (source.IsNumber() && source.ToNumber() == 0) || (source is string && string.IsNullOrEmpty(source.ToString())) || source == null;

            return this.ToResult(property, !result);
        }
    }
}