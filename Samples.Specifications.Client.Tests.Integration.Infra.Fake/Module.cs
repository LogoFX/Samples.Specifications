using Attest.Testing.Contracts;
using Attest.Testing.Core;
using Attest.Testing.Core.FakeData;
using JetBrains.Annotations;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Fake
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator) => dependencyRegistrator
            .AddSingleton<IStartApplicationService, StartApplicationService>()
            .AddSingleton<IBuilderRegistrationService, BuilderRegistrationService>()
            .AddSingleton<ISetupService, SetupServiceBase>();
    }
}
