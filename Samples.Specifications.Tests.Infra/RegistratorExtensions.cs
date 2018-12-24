using Attest.Testing.Contracts;
using Solid.Practices.IoC;

namespace Samples.Specifications.Tests.Infra
{
    //TODO: Move to packages
    public static class RegistratorExtensions
    {
        public static IDependencyRegistrator UseLocalApplicationForIntegration(this IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.RegisterSingleton<IStartLocalApplicationService, Attest.Testing.Integration.StartLocalApplicationService>();
            return dependencyRegistrator;
        }

        public static IDependencyRegistrator UseLocalApplicationForEndToEnd(this IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.RegisterSingleton<IStartLocalApplicationService, Attest.Testing.EndToEnd.StartLocalApplicationService>();
            return dependencyRegistrator;
        }
    }
}