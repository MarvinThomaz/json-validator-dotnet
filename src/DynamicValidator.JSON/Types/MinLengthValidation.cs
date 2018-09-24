﻿using DynamicValidator.Abstractions;
using System;

namespace DynamicValidator.JSON.Types
{
    /// <summary>
    /// Classe que valida uma determinada propriedade a partir do tamanho mínimo permitido.
    /// </summary>
    public class MinLengthValidation : IValidation
    {
        private int _value;

        /// <summary>
        /// Valor da propriedade a ser validada.
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
        /// Código de erro caso o tamanho mínimo seja menor que o esperado.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Mensagem de erro caso o tamanho mínimo seja menor que o esperado.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Método utilizado para validar o tamanho mínimo.
        /// </summary>
        /// <param name="property">Propriedade onde o tamanho mínimo foi aplicado.</param>
        /// <param name="source">Objeto onde o valor será resgatado</param>
        /// <returns>Resultado da validação.</returns>
        public ValidationResult Validate(string property, object source)
        {
            if (source is string)
            {
                var result = source.ToString()?.Length < _value;

                return this.ToResult(property, !result);
            }

            return this.ToResult(property, false);
        }
    }
}