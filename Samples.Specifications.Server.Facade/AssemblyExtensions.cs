using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Samples.Specifications.Server.Facade
{
    //TODO: Consider moving to infra package
    public static class AssemblyExtensions
    {
        public static IConfiguration BuildConfiguration(this Assembly assembly)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"{assembly.GetName().Name}.json");
            return builder.Build();
        }

        public static void SetWorkingDir(this Assembly assembly)
        {
            var executingDir = Path.GetDirectoryName(assembly.Location);
            Directory.SetCurrentDirectory(executingDir);
        }
    }
}