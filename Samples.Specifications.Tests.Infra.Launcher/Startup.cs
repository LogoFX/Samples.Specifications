using Solid.Bootstrapping;
using Solid.Practices.IoC;

namespace Samples.Specifications.Tests.Infra.Launcher
{
    internal sealed class Startup
    {
        private readonly IDependencyRegistrator _dependencyRegistrator;

        public Startup(IDependencyRegistrator dependencyRegistrator) => _dependencyRegistrator = dependencyRegistrator;

        public void Initialize() => new Bootstrapper(_dependencyRegistrator)
            .Use(new ModulesRegistrationMiddleware<Bootstrapper>()).Initialize();
        
    }
}
