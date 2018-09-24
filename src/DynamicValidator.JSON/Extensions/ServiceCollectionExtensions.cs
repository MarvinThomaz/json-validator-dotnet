using DynamicValidator.JSON.Abstractions;
using DynamicValidator.JSON.Commands;

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
        public static void AddValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidateCommand, ValidateWithJSONCommand>();
        }
    }
}