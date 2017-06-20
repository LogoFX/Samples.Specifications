using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using LogoFX.Client.Testing.EndToEnd.FakeData.Modularity;
using LogoFX.Client.Testing.EndToEnd.FakeData.Shared;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;
using Solid.Practices.Composition;
using Solid.Practices.IoC;

namespace Samples.Specifications.Tests.EndToEnd.Infra.Providers
{    
    [UsedImplicitly]
    public class Module : ProvidersModuleBase
    {
        private const string ProvidersAssemblyEnding = "Contracts.Providers";
        private const string BuildersAssemblyEnding = "Fake.ProviderBuilders";

        protected override void OnRegisterProviders(IIocContainerRegistrator iocContainer)
        {
            base.OnRegisterProviders(iocContainer);
            //TODO: move the code below to the packages
            const string builderEnding = "Builder";
            const string providerEnding = "Provider";
            var assembliesProvider = new ProvidersAssemblySourceProvider(PlatformProvider.Current.GetRootPath());
            var allAssemblies = assembliesProvider.Assemblies.ToArray();            
            var providersAssemblies = allAssemblies.Where(t => t.GetName().Name.EndsWith(ProvidersAssemblyEnding));
            var matchingProvidersTypes = providersAssemblies.SelectMany(k => k.DefinedTypes
                .Where(t => t.IsInterface && t.Name.EndsWith(providerEnding))
                .Select(t => t.AsType())).ToArray();
            var buildersAssemblies = allAssemblies.Where(t => t.GetName().Name.EndsWith(BuildersAssemblyEnding));
            var matchingBuildersTypes = buildersAssemblies.SelectMany(k => k.DefinedTypes
                .Where(t => t.IsInterface == false && t.IsAbstract == false && t.Name.EndsWith(builderEnding))
                .Select(t => t.AsType())).ToArray();
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

        public class ProvidersAssemblySourceProvider : AssemblySourceProviderBase
        {
            public ProvidersAssemblySourceProvider(string rootPath) : base(rootPath)
            {
            }

            protected override string[] ResolveNamespaces()
            {
                return new[] {ProvidersAssemblyEnding, BuildersAssemblyEnding};
            }
        }
    }

    
}
