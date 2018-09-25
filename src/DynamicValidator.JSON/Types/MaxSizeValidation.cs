using DynamicValidator.Abstractions;
using System;

namespace DynamicValidator.JSON.Types
{
    /// <summary>
    /// Classe que define a validação de valor máximo de uma propriedade
    /// </summary>
    public class MaxSizeValidation : IMaxSizeValidation
    {
        private int _value;

        /// <summary>
        /// Valor que define o valor máximo
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Valor que define o código de erro caso o valor máximo seja ultrapassado.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Mensagem que é usada caso o valor máximo seja ultrapassado.
        /// </summary>
        public string Message { get; set; }
    }
}