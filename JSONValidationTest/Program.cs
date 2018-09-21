using JSONValidationTest.Validation;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace JSONValidationTest
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
