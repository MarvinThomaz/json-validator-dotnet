namespace DynamicValidator.Abstractions
{
    /// <summary>
    /// Classe de resultado de validação focada em erros.
    /// </summary>
    public class ValidationError : IValidationInfo
    {
        /// <summary>
        /// Propriedade onde a validação foi aplicada.
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// Codigo do erro que foi mapeado.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Mensagem do erro que foi mapeado.
        /// </summary>
        public string Message { get; set; }
    }
}