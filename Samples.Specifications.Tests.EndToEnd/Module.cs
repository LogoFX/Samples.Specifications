using Attest.Testing.Contracts;
using Attest.Testing.EndToEnd;
using JetBrains.Annotations;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator) => dependencyRegistrator
            .AddSingleton<IApplicationPathInfo, ApplicationPathInfo>()
            .AddSingleton<IStartLocalApplicationService, StartLocalApplicationService>();
    }
}
