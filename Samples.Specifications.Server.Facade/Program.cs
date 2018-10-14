using System.IO;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Samples.Specifications.Server.Facade
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var executingDir = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
            Directory.SetCurrentDirectory(executingDir);

            //TODO: Have to provide the start urls during web host build                 
            BuildWebHost(args, new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build()).Run();
        }

        private static IWebHost BuildWebHost(string[] args, IConfiguration configuration) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseConfiguration(configuration)
                .Build();
    }
}
