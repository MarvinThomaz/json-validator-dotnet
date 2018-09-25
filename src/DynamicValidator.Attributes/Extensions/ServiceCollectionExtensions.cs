using DynamicValidator.Abstractions;
using DynamicValidator.Attributes.Commands;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Classe utilizada para disponibilizar extensões do service collection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Método utilizado para adicionar as dependencias de validação ao service collection da aplicação.
        /// </summary>
        /// <param name="services">Service collection da aplicação.</param>
        public static void AddAttributesValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidateCommand, ValidateWithAttributesCommand>();
        }
    }
}