using DynamicValidator.Abstractions;
using System;

namespace DynamicValidator.JSON.Types
{
    /// <summary>
    /// Classe que realiza validação de propriedade obrigatória.
    /// </summary>
    public class RequiredValidation : IRequiredValidation
    {
        /// <summary>
        /// Valor que define se a propriedade será obrigatória.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Código de erro caso a propriedade não atenda a validação.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Mensagem de erro caso a propriedade não atenda a validação.
        /// </summary>
        public string Message { get; set; }
    }
}