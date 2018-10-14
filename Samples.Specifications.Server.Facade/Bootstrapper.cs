using LogoFX.Server.Bootstrapping;
using Microsoft.Extensions.DependencyInjection;

namespace Samples.Specifications.Server.Facade
{
    internal sealed class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper(IServiceCollection dependencyRegistrator) : base(dependencyRegistrator)
        {
        }

        public override string[] Prefixes => new[] { "Samples.Specifications" };
    }
}
