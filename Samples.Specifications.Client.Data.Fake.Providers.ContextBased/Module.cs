using System.Linq;
using Attest.Fake.Data;
using Attest.Fake.Data.Modularity;
using Attest.Fake.Registration;
using JetBrains.Annotations;
using Samples.Specifications.Client.Data.Fake.Shared;
using Solid.Practices.IoC;

namespace Samples.Specifications.Client.Data.Fake.Providers.ContextBased
{    
    [UsedImplicitly]
    internal sealed class Module : ProvidersModuleBase<IDependencyRegistrator>
    {       
        protected override void RegisterProviders(IDependencyRegistrator dependencyRegistrator)
        {
            var builders = BuildersCollectionHelper.FillMissingBuilders(
                ConventionsHelper.FindContractToBuilderMatches().Values.ToArray(),
                BuilderFactory.CreateBuilderInstance);
            dependencyRegistrator.RegisterBuilders(RegistrationHelper.RegisterBuilderProduct,
                ConventionsHelper.FindContractToBuilderMatches(), builders);
        }
    }    
}
