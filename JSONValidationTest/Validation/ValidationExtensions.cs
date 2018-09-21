using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace JSONValidationTest.Validation
{
    public static class ValidationExtensions
    {
        public static void AddValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator, Validator>();
        }

        public static IWebHostBuilder ConfigureValidation(this IWebHostBuilder builder, string configurationFile)
        {
            return builder.ConfigureAppConfiguration(config =>
            { 
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile(configurationFile, optional: true, reloadOnChange: true);          
            });
        }

        public static bool IsNumber(this object source)
        {
            return source is int || source is long || source is short || source is decimal || source is double || source is float;
        }

        public static decimal ToNumber(this object source)
        {
            if (source.IsNumber())
                return Convert.ToDecimal(source);

            return 0;
        }

        public static ValidationResult FromInfo(this ValidationInfo info, string property, bool result)
        {
            return new ValidationResult(info, property, result);
        }
    }
}