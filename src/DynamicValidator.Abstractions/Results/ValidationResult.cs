namespace DynamicValidator.Abstractions
{
    /// <summary>
    /// Classe de resultado da validação.
    /// </summary>
    public class ValidationResult : IValidationInfo
    {
        /// <summary>
        /// Constrói o objeto baseado em um info, nome da propriedade de valor do resultado.
        /// </summary>
        /// <param name="validation">Validação prévia.</param>
        /// <param name="property">Propriedade que foi validada</param>
        /// <param name="result">Resultado da validação.</param>
        public ValidationResult(IValidationInfo validation, string property, bool result)
        {
            Property = property;
            Result = result;
            Code = validation.Code;
            Message = validation.Message;
        }

        /// <summary>
        /// Resultado da validação.
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// Propriedade que foi validada.
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// Código do resultado.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Mensagem do resultado.
        /// </summary>
        public string Message { get; set; }
    }
}