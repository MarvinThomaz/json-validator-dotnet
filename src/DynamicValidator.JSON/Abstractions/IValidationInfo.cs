namespace DynamicValidator.JSON.Abstractions
{
    /// <summary>
    /// Interface de resultado de validações.
    /// </summary>
    public interface IValidationInfo
    {
        /// <summary>
        /// Código da validação.
        /// </summary>
        int Code { get; set; }

        /// <summary>
        /// Mensagem da validação.
        /// </summary>
        string Message { get; set; }
    }
}