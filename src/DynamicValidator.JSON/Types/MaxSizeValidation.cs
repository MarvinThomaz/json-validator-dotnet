using DynamicValidator.Abstractions;
using System;

namespace DynamicValidator.JSON.Types
{
    /// <summary>
    /// Classe que define a validação de valor máximo de uma propriedade
    /// </summary>
    public class MaxSizeValidation : IValidation
    {
        private int _value;

        /// <summary>
        /// Valor que define o valor máximo
        /// </summary>
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = (int)value.ToNumber();
            }
        }

        /// <summary>
        /// Valor que define o código de erro caso o valor máximo seja ultrapassado.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Mensagem que é usada caso o valor máximo seja ultrapassado.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Método que executa a validação.
        /// </summary>
        /// <param name="property">Propriedade do objeto que será validada</param>
        /// <param name="source">Objeto que contém o valor a ser validado.</param>
        /// <returns>Resultado da validação</returns>
        public ValidationResult Validate(string property, object source)
        {
            var result = source.ToNumber() > _value;

            return this.ToResult(property, !result);
        }
    }
}