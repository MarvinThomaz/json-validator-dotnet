using Microsoft.Extensions.Configuration;
using System.IO;

namespace Microsoft.AspNetCore.Hosting
{
    /// <summary>
    /// Classe que contém extensões para a configuração do inicio da aplicação.
    /// </summary>
    public static class WebHostBuilderExtensions
    {
        /// <summary>
        /// Método que configura a validação em JSON buscando de um determinado arquivo.
        /// </summary>
        /// <param name="builder">Constrói a applicação com as configurações expecíficas necessárias para inicialização.</param>
        /// <param name="configurationFile">Nome do arquivo de onde será buscado o JSON.</param>
        /// <returns>Instância do <see cref="IWebHostBuilder"/> configurada.</returns>
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