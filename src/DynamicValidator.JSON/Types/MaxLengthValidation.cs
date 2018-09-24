using DynamicValidator.Abstractions;
using System;

namespace DynamicValidator.JSON.Types
{
    /// <summary>
    /// Classe que define os parametros para validação de tamanho máximo de uma propriedade.
    /// </summary>
    public class MaxLengthValidation : IValidation
    {
        /// <summary>
        /// Valor que define o tamanho máximo da propriedade.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Código de erro a ser aplicado caso o tamanho máximo seja ultrapassado.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Mensagem de erro a ser aplicada caso o tamanho máximo seja ultrapassado.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Método que realiza a validação de tamanho máximo de propriedade.
        /// </summary>
        /// <param name="property">Propriedade a ser validada</param>
        /// <param name="source">Objeto de onde o valor será retirado.</param>
        /// <returns>Resultado da validação.</returns>
        public ValidationResult Validate(string property, object source)
        {
            if (source is string)
            {
                var result = (source as string).Length > Convert.ToInt32(Value);

                return this.ToResult(property, !result);
            }

            return this.ToResult(property, false);
        }
    }
}