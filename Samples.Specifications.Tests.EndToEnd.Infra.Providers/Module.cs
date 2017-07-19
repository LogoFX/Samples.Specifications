using System;
using System.Linq;
using Attest.Fake.Registration;
using JetBrains.Annotations;
using LogoFX.Client.Testing.EndToEnd.FakeData.Modularity;
using LogoFX.Client.Testing.EndToEnd.FakeData.Shared;
using Samples.Specifications.Client.Data.Fake.Shared;
using Solid.Patterns.Builder;
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
                RegisterAllBuildersInternal(iocContainer, (IBuilder)instance, typeMatch.Key, typeMatch.Value);
            }            
        }

        private void RegisterAllBuildersInternal(IIocContainerRegistrator iocContainerRegistrator,
            IBuilder builderInstance, Type builderType, Type providerType)
        {
            var builders = BuildersCollectionContext.GetBuilders(builderType).OfType<IBuilder>().ToArray();
            if (builders.Length == 0)
            {
                RegistrationHelper.RegisterBuilder(iocContainerRegistrator,providerType, builderInstance);                
            }
            else
            {
                foreach (var builder in builders)
                {
                    RegistrationHelper.RegisterBuilder(iocContainerRegistrator, providerType, builder);
                }
            }
        }        
    }    
}
