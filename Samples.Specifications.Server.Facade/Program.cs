using System.Reflection;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Samples.Specifications.Server.Facade
{
    /// <summary>
    /// Entry point for the program
    /// </summary>
    [UsedImplicitly]
    public class Program
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            Assembly.GetCallingAssembly().SetWorkingDir();
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .UseConfiguration(Assembly.GetExecutingAssembly().BuildConfiguration());
                });
    }
}
