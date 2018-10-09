using Attest.Testing.Core.FakeData.Modularity;
using Attest.Testing.Core.FakeData.Shared;
using JetBrains.Annotations;
using Samples.Specifications.Client.Data.Fake.Shared;
using Solid.Practices.IoC;

namespace Samples.Specifications.Client.Data.Fake.Providers.ContextBased
{    
    [UsedImplicitly]
    internal sealed class Module : ProvidersModuleBase
    {       
        protected override void OnRegisterProviders(IDependencyRegistrator dependencyRegistrator)
        {
            base.OnRegisterProviders(dependencyRegistrator);
            dependencyRegistrator.RegisterBuildersProducts(ConventionsHelper.FindContractToBuilderMatches(),
                BuilderFactory.CreateBuilderInstance);                  
        }
    }    
}
