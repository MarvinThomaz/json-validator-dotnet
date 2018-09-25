using DynamicValidator.Abstractions;
using System;

namespace DynamicValidator.JSON.Types
{
    /// <summary>
    /// Classe que valida uma determinada propriedade a partir do tamanho mínimo permitido.
    /// </summary>
    public class MinLengthValidation : IMinLengthValidation
    {
        /// <summary>
        /// Valor da propriedade a ser validada.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Código de erro caso o tamanho mínimo seja menor que o esperado.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Mensagem de erro caso o tamanho mínimo seja menor que o esperado.
        /// </summary>
        public string Message { get; set; }
    }
}