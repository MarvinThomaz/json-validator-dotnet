using DynamicValidator.JSON.Abstractions;
using System;

namespace DynamicValidator.JSON.Types
{
    /// <summary>
    /// Classe utilizada para validar o valor mínimo de uma propriedade.
    /// </summary>
    public class MinSizeValidation : IValidation
    {
        /// <summary>
        /// Valor mínimo a ser validado.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Código de erro caso o valor seja menor que o mínimo esperado.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Mensagem de erro caso o valor seja menor que o mínimo esperado.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Método que realiza a validação.
        /// </summary>
        /// <param name="property">Propriedade a ser validada.</param>
        /// <param name="source">Objeto onde o valor da propriedade será resgatado.</param>
        /// <returns>Resultado da validação.</returns>
        public ValidationResult Validate(string property, object source)
        {
            var result = source.ToNumber() < Convert.ToInt32(Value);

            return this.ToResult(property, !result);
        }
    }
}