using Attest.Testing.Contracts;
using Attest.Testing.Core.FakeData;
using LogoFX.Client.Testing.Contracts;
using Samples.Specifications.Client.Tests.Integration.Infra.Real;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Fake
{
    class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.AddSingleton<IStartApplicationService, StartApplicationService>();
        }
    }
}
