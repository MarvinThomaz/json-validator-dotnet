using DynamicValidator.Abstractions;
using System;

namespace DynamicValidator.JSON.Types
{
    /// <summary>
    /// Classe utilizada para validar o valor mínimo de uma propriedade.
    /// </summary>
    public class MinSizeValidation : IMinSizeValidation
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
    }
}