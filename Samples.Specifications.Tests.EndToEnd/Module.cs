using Attest.Testing.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd
{
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator) => dependencyRegistrator
            .AddSingleton<IApplicationPathInfo, ApplicationPathInfo>()
            .AddSingleton<IStartLocalApplicationService, Attest.Testing.EndToEnd.StartLocalApplicationService>();
    }
}
