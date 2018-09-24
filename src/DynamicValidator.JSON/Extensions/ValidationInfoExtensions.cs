using DynamicValidator.Abstractions;

namespace DynamicValidator.Abstractions
{
    /// <summary>
    /// Método utilizado para disponibilizar extensões para o <see cref="IValidationInfo"/>.
    /// </summary>
    public static class ValidationInfoExtensions
    {
        /// <summary>
        /// Método que transforma um <see cref="IValidationInfo"/> em <see cref="ValidationResult"/>.
        /// </summary>
        /// <param name="info">Objeto a ser transformado.</param>
        /// <param name="property">Nome da propriedade.</param>
        /// <param name="result">Resultado da operação.</param>
        /// <returns>Instância de <see cref="ValidationResult"/></returns>
        public static ValidationResult ToResult(this IValidationInfo info, string property, bool result)
        {
            return new ValidationResult(info, property, result);
        }
    }
}