using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DynamicValidator.JSON.Extensions
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder ConfigureValidation(this IWebHostBuilder builder, string configurationFile)
        {
            return builder.ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile(configurationFile, optional: true, reloadOnChange: true);
            });
        }
    }
}