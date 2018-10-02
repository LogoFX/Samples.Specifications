using Attest.Testing.Contracts;
using Solid.Practices.IoC;

namespace Samples.Specifications.Tests.Infra.Launcher
{
    public static class Extensions
    {
        public static void Initialize(this IDependencyRegistrator dependencyRegistrator)
        {
            new Startup(dependencyRegistrator).Initialize();
        }

        public static void Setup(this IDependencyResolver dependencyResolver)
        {
            var setupService = dependencyResolver.Resolve<ISetupService>();
            setupService.Setup();
        }
        
        public static void Teardown(this IDependencyResolver dependencyResolver)
        {
            var teardownService = dependencyResolver.Resolve<ITeardownService>();
            teardownService.Teardown();
        }
    }
}