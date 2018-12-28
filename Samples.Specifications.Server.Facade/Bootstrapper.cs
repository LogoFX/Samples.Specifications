using LogoFX.Server.Bootstrapping;
using Microsoft.Extensions.DependencyInjection;
using Solid.Practices.Composition;

namespace Samples.Specifications.Server.Facade
{
    internal sealed class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper(IServiceCollection dependencyRegistrator) : base(dependencyRegistrator)
        {
        }

        public override CompositionOptions CompositionOptions => new CompositionOptions
        {
            Prefixes = new[] {"Samples.Specifications"}
        };
    }
}
