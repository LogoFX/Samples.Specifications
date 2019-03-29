using System.Linq;
using Attest.Fake.Conventions;
using Attest.Fake.Data;
using Attest.Fake.Data.Modularity;
using Attest.Fake.Registration;
using JetBrains.Annotations;
using Solid.Practices.IoC;

namespace Samples.Specifications.Client.Data.Fake.Providers.ContextBased
{    
    [UsedImplicitly]
    internal sealed class Module : ProvidersModuleBase<IDependencyRegistrator>
    {       
        protected override void RegisterProviders(IDependencyRegistrator dependencyRegistrator)
        {
            var builders = BuildersCollectionHelper.FillMissingBuilders(
                TypeLocator.FindContractToBuilderMatches().Values.ToArray(),
                BuilderFactory.CreateBuilderInstance);
            dependencyRegistrator.RegisterBuilders(RegistrationHelper.RegisterBuilderProduct,
                TypeLocator.FindContractToBuilderMatches(), builders);
        }
    }    
}
