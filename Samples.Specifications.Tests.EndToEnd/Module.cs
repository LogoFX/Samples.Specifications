using Attest.Testing.Contracts;
using JetBrains.Annotations;
using Samples.Specifications.Tests.Infra;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator) => dependencyRegistrator
            .AddSingleton<IApplicationPathInfo, ApplicationPathInfo>()
            .UseLocalApplicationForEndToEnd();
    }
}
