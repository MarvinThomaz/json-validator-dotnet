namespace DynamicValidator.Abstractions
{
    /// <summary>
    /// Interface que baseada em informações basicas de uma propriedade adiciona propriedades de validação.
    /// </summary>
    public interface IValidation : IValidationInfo
    {
        /// <summary>
        /// Valor da validação a ser aplicada.
        /// </summary>
        object Value { get; set; }
    }
}