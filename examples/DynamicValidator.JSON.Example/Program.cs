using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using DynamicValidator.JSON.Extensions;

namespace DynamicValidator.JSON.Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureValidation("domainValidations.json")
                .UseStartup<Startup>();
    }
}