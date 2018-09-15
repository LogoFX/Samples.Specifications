using System;
using System.Linq;
using Attest.Fake.Registration;
using Attest.Testing.Core.FakeData.Modularity;
using Attest.Testing.Core.FakeData.Shared;
using JetBrains.Annotations;
using Samples.Specifications.Client.Data.Fake.Shared;
using Solid.Patterns.Builder;
using Solid.Practices.IoC;

namespace Samples.Specifications.Client.Data.Fake.Providers.ContextBased
{    
    [UsedImplicitly]
    internal sealed class Module : ProvidersModuleBase
    {       
        protected override void OnRegisterProviders(IDependencyRegistrator dependencyRegistrator)
        {
            base.OnRegisterProviders(dependencyRegistrator);            
            var typeMatches = Helper.FindProviderMatches();            
            foreach (var typeMatch in typeMatches)
            {
                var instance = Helper.CreateInstance(typeMatch.Key);
                RegisterAllBuildersInternal(dependencyRegistrator, (IBuilder)instance, typeMatch.Key, typeMatch.Value);
            }            
        }

        private static void RegisterAllBuildersInternal(IDependencyRegistrator dependencyRegistrator,
            IBuilder builderInstance, Type builderType, Type providerType)
        {
            var builders = BuildersCollectionContext.GetBuilders(builderType).OfType<IBuilder>().ToArray();
            if (builders.Length == 0)
            {
                RegistrationHelper.RegisterBuilder(dependencyRegistrator, providerType, builderInstance);                
            }
            else
            {
                foreach (var builder in builders)
                {
                    RegistrationHelper.RegisterBuilder(dependencyRegistrator, providerType, builder);
                }
            }
        }        
    }    
}
