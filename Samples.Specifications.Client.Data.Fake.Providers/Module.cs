using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Samples.Client.Data.Contracts.Dto;
using Samples.Specifications.Client.Data.Fake.Containers;
using Solid.Practices.Composition;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Data.Fake.Providers
{
    [UsedImplicitly]
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        private const string ProvidersAssemblyEnding = "Contracts.Providers";
        private const string FakeProvidersAssemblyEnding = "Fake.Providers";
        private const string BuildersAssemblyEnding = "Fake.ProviderBuilders";        

        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            RegisterDataContainers(iocContainer);
            const string builderEnding = "Builder";
            const string providerEnding = "Provider";
            const string fakePrefix = "Fake";
            var assembliesProvider = new ProvidersAssemblySourceProvider(PlatformProvider.Current.GetRootPath());
            var allAssemblies = assembliesProvider.Assemblies.ToArray();
            var providersAssemblies = allAssemblies.Where(t => t.GetName().Name.EndsWith(ProvidersAssemblyEnding));
            var matchingProvidersContractsTypes = providersAssemblies.SelectMany(k => k.DefinedTypes
                .Where(t => t.IsInterface && t.Name.EndsWith(providerEnding))
                .Select(t => t.AsType())).ToArray();
            var fakeProvidersAssemblies = allAssemblies.Where(t => t.GetName().Name.EndsWith(FakeProvidersAssemblyEnding));
            var matchingFakeProvidersTypes = fakeProvidersAssemblies.SelectMany(k => k.DefinedTypes
                .Where(t => t.IsInterface == false && t.IsAbstract == false && t.Name.EndsWith(providerEnding))
                .Select(t => t.AsType())).ToArray();
            var fakeTypeMatches = new Dictionary<Type, Type>();
            foreach (var type in matchingFakeProvidersTypes)
            {
                var matchingProviderContractType =
                    matchingProvidersContractsTypes.FirstOrDefault(
                        t => t.Name == "I" + type.Name.Replace(fakePrefix, string.Empty));
                if (matchingProviderContractType != null)
                {
                    fakeTypeMatches.Add(matchingProviderContractType, type);
                }
            }

            var buildersAssemblies = allAssemblies.Where(t => t.GetName().Name.EndsWith(BuildersAssemblyEnding));
            var matchingBuildersTypes = buildersAssemblies.SelectMany(k => k.DefinedTypes
                .Where(t => t.IsInterface == false && t.IsAbstract == false && t.Name.EndsWith(builderEnding))
                .Select(t => t.AsType())).ToArray();
            var builderTypeMatches = new Dictionary<Type, Type>();
            foreach (var type in matchingBuildersTypes)
            {
                var matchingProviderType =
                    matchingProvidersContractsTypes.FirstOrDefault(
                        t => t.Name == "I" + type.Name.Replace(builderEnding, string.Empty));
                if (matchingProviderType != null)
                {
                    builderTypeMatches.Add(type, matchingProviderType);
                }
            }            
            
            foreach (var typeMatch in fakeTypeMatches)
            {
                iocContainer.RegisterSingleton(typeMatch.Key, typeMatch.Value);
            }
            const string methodName = "CreateBuilder";
            foreach (var typeMatch in builderTypeMatches)
            {
                var instance = typeMatch.Key.GetRuntimeMethod(methodName, new Type[] { }).Invoke(null, null);
                iocContainer.RegisterInstance(typeMatch.Key, instance);
            }                        
        }

        private static void RegisterDataContainers(IIocContainerRegistrator iocContainer)
        {
            var warehouseContainer = InitializeWarehouseContainer();
            var userContainer = InitializeUserContainer();
            iocContainer.RegisterInstance(warehouseContainer);
            iocContainer.RegisterInstance(userContainer);            
        }

        private static IWarehouseContainer InitializeWarehouseContainer()
        {
            var warehouseContainer = new WarehouseContainer();
            warehouseContainer.UpdateWarehouseItems(new[]
            {
                new WarehouseItemDto
                {
                    Kind = "PC",
                    Price = 25.43,
                    Quantity = 8
                },

                new WarehouseItemDto
                {
                    Kind = "Acme",
                    Price = 10,
                    Quantity = 10
                },

                new WarehouseItemDto
                {
                    Kind = "Bacme",
                    Price = 20,
                    Quantity = 3
                },

                new WarehouseItemDto
                {
                    Kind = "Exceed",
                    Price = 0.4,
                    Quantity = 100
                },

                new WarehouseItemDto
                {
                    Kind = "Acme2",
                    Price = 1,
                    Quantity = 10
                }
            });
            return warehouseContainer;
        }

        private static IUserContainer InitializeUserContainer()
        {
            var userContainer = new UserContainer();
            userContainer.UpdateUsers(new []
            {
                new Tuple<string, string>("Admin", "pass") 
            });
            return userContainer;
        }

        public class ProvidersAssemblySourceProvider : AssemblySourceProviderBase
        {
            public ProvidersAssemblySourceProvider(string rootPath) : base(rootPath)
            {
            }

            protected override string[] ResolveNamespaces()
            {
                return new[] {ProvidersAssemblyEnding, FakeProvidersAssemblyEnding, BuildersAssemblyEnding};
            }
        }
    }
}
