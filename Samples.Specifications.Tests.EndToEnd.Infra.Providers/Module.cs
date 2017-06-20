using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using LogoFX.Client.Testing.EndToEnd.FakeData.Modularity;
using LogoFX.Client.Testing.EndToEnd.FakeData.Shared;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;
using Solid.Practices.IoC;

namespace Samples.Specifications.Tests.EndToEnd.Infra.Providers
{    
    [UsedImplicitly]
    public class Module : ProvidersModuleBase
    {
        protected override void OnRegisterProviders(IIocContainerRegistrator iocContainer)
        {
            base.OnRegisterProviders(iocContainer);
            const string builderEnding = "Builder";
            const string providerEnding = "Provider";
            var providersAssemblyName = "Samples.Client.Data.Contracts.Providers";
            var providersAssembly = Assembly.Load(new AssemblyName(providersAssemblyName));
            var matchingProvidersTypes = providersAssembly.DefinedTypes
                .Where(t => t.IsInterface && t.Name.EndsWith(providerEnding))
                .Select(t => t.AsType()).ToArray();
            var buildersAssemblyName = "Samples.Specifications.Client.Data.Fake.ProviderBuilders";            
            var buildersAssembly = Assembly.Load(new AssemblyName(buildersAssemblyName));            
            var matchingBuildersTypes = buildersAssembly.DefinedTypes
                .Where(t => t.IsInterface == false && t.Name.EndsWith(builderEnding))
                .Select(t => t.AsType());
            var typeMatches = new Dictionary<Type, Type>();
            foreach (var type in matchingBuildersTypes)
            {
                var matchingProviderType =
                    matchingProvidersTypes.FirstOrDefault(
                        t => t.Name == "I" + type.Name.Replace(builderEnding, string.Empty));
                if (matchingProviderType != null)
                {
                    typeMatches.Add(type, matchingProviderType);
                }
            }
            const string methodName = "CreateBuilder";
            foreach (var typeMatch in typeMatches)
            {
                var instance = typeMatch.Key.GetRuntimeMethod(methodName, new Type[] { }).Invoke(null, null);
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
