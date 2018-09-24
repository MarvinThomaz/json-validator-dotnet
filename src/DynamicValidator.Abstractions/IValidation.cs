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

        /// <summary>
        /// Método que executa a validação.
        /// </summary>
        /// <param name="property">Propriedade que será validada.</param>
        /// <param name="source">Objeto a ser validado.</param>
        /// <returns></returns>
        ValidationResult Validate(string property, object source);
    }
}