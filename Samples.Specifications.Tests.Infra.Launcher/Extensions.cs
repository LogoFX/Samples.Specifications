using Attest.Testing.Contracts;
using Solid.Practices.IoC;

namespace Samples.Specifications.Tests.Infra.Launcher
{
    public static class Extensions
    {
        public static void Initialize(this IIocContainer iocContainer) =>
            new Startup(iocContainer).Initialize();

        public static void Setup(this IDependencyResolver dependencyResolver)
        {
            var setupServices = dependencyResolver.ResolveAll<ISetupService>();
            foreach (var setupService in setupServices)
            {
                setupService.Setup();
            }            
        }

        public static void Teardown(this IDependencyResolver dependencyResolver)
        {
            var applicationModules = dependencyResolver.ResolveAll<IDynamicApplicationModule>();
            foreach (var applicationModule in applicationModules)
            {
                applicationModule.Stop();
            }
            var teardownServices = dependencyResolver.ResolveAll<ITeardownService>();
            foreach (var teardownService in teardownServices)
            {
                teardownService.Teardown();
            }
        }
    }
}