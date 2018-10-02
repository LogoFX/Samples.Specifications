using Attest.Testing.Contracts;
using Solid.Practices.IoC;

namespace Samples.Specifications.Tests.Infra.Launcher
{
    public static class Extensions
    {
        public static void Initialize(this IDependencyRegistrator dependencyRegistrator) =>
            new Startup(dependencyRegistrator).Initialize();

        public static void Setup(this IDependencyResolver dependencyResolver) =>
            dependencyResolver.Resolve<ISetupService>().Setup();

        public static void Teardown(this IDependencyResolver dependencyResolver) =>
            dependencyResolver.Resolve<ITeardownService>().Teardown();
    }
}