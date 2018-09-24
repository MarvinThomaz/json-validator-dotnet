using DynamicValidator.JSON.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicValidator.JSON.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidatorApplicationService, ValidatorApplicationService>();
        }
    }
}