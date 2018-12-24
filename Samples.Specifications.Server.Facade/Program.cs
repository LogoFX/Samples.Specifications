using System.IO;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Samples.Specifications.Server.Facade
{
    /// <summary>
    /// Entry point for the program
    /// </summary>
    [UsedImplicitly]
    public class Program
    {
        private static IConfiguration Configuration { get; set; }

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            var executingDir = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
            Directory.SetCurrentDirectory(executingDir);

            var builder = new ConfigurationBuilder()
                .AddJsonFile("Samples.Specifications.Server.Facade.json");
            Configuration = builder.Build();

            BuildWebHost(args).Run();
        }

        /// <summary>
        /// Builds the web host.
        /// </summary>
        /// <returns>The web host.</returns>
        /// <param name="args">Arguments.</param>
        private static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseConfiguration(Configuration)
                .Build();
    }
}
