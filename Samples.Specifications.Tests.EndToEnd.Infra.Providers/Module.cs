using System;
using System.Linq;
using JetBrains.Annotations;
using LogoFX.Client.Testing.EndToEnd.FakeData.Modularity;
using LogoFX.Client.Testing.EndToEnd.FakeData.Shared;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;
using Samples.Specifications.Client.Data.Fake.Shared;
using Solid.Practices.IoC;

namespace Samples.Specifications.Tests.EndToEnd.Infra.Providers
{    
    [UsedImplicitly]
    public class Module : ProvidersModuleBase
    {       
        protected override void OnRegisterProviders(IIocContainerRegistrator iocContainer)
        {
            base.OnRegisterProviders(iocContainer);            
            var typeMatches = Helper.FindProviderMatches();            
            foreach (var typeMatch in typeMatches)
            {
                var instance = Helper.CreateInstance(typeMatch.Key);
                RegisterAllBuildersInternal(iocContainer, (IFakeProviderBuilder)instance, typeMatch.Key, typeMatch.Value);
            }            
        }

        protected void RegisterAllBuildersInternal(IIocContainerRegistrator iocContainerRegistrator,
           IFakeProviderBuilder builderInstance, Type builderType, Type providerType)
        {
            var builders = BuildersCollectionContext.GetBuilders(builderType).OfType<IFakeProviderBuilder>().ToArray();
            if (builders.Length == 0)
            {
                iocContainerRegistrator.RegisterTransient(providerType, providerType, builderInstance.Build);
            }
            else
            {
                foreach (var builder in builders)
                {
                    iocContainerRegistrator.RegisterTransient(providerType, providerType, builder.Build);
                }
            }
        }        
    }    
}
