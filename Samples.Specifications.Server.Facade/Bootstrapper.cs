using System.IO;
using LogoFX.Server.Bootstrapping;
using Microsoft.Extensions.DependencyInjection;

namespace Samples.Specifications.Server.Facade
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper(IServiceCollection dependencyRegistrator) : base(dependencyRegistrator)
        {
        }

        public override string ModulesPath => CalculateModulesPath();

        private static string CalculateModulesPath()
        {
            var configuration = GetCurrentConfiguration();
            return configuration == string.Empty
                ? "."
                : Path.Combine(new[] {"..", "bin", "Server", configuration});
        }

        private static string GetCurrentConfiguration() =>
#if RELEASE
        string.Empty
#elif DEBUGWITHFAKE
        "DebugWithFake"
#elif DEBUGWITHREAL
        "DebugWithReal"
#else
            "Debug"
#endif
        ;

        public override string[] Prefixes => new[] {"Samples.Specifications"};
    }
}
