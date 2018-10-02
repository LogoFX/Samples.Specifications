using LogoFX.Bootstrapping;
using Solid.Practices.IoC;

namespace Samples.Specifications.Tests.Infra.Launcher
{
    internal sealed class Startup
    {
        private readonly IDependencyRegistrator _dependencyRegistrator;

        public Startup(IDependencyRegistrator dependencyRegistrator)
        {
            _dependencyRegistrator = dependencyRegistrator;                   
        }

        public void Initialize()
        {
            var bootstrapper =
                new Bootstrapper(_dependencyRegistrator)
                    .Use(new RegisterCompositionModulesMiddleware<Bootstrapper>());            
            bootstrapper.Initialize();
        }
    }
}
