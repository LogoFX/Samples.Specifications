using System;
using System.Collections.Generic;
using System.Linq;
using Solid.Practices.Composition;
using Solid.Practices.IoC;

namespace Samples.Specifications.Client.Data.Fake.Shared
{
    public static class RegistrationExtensions
    {
        public static void RegisterBuildersAndFakeProviders(this IDependencyRegistrator dependencyRegistrator)
        {
            var assembliesProvider = new ProvidersAssemblySourceProvider(PlatformProvider.Current.GetRootPath());
            var allAssemblies = assembliesProvider.Assemblies.ToArray();
            var contractTypes = allAssemblies.FindContractTypes();
            var fakeTypes = allAssemblies.FindFakeTypes();
            var contractToFakeMatches = new Dictionary<Type, Type>();
            foreach (var type in fakeTypes)
            {
                var contractType =
                    contractTypes.FirstOrDefault(
                        t => t.Name == "I" + type.Name.Replace(Consts.FakePrefix, string.Empty));
                if (contractType != null)
                {
                    contractToFakeMatches.Add(contractType, type);
                }
            }

            foreach (var contractToFakeMatch in contractToFakeMatches)
            {
                dependencyRegistrator.RegisterSingleton(contractToFakeMatch.Key, contractToFakeMatch.Value);
            }

            var contractToBuilderMatches =
                allAssemblies.FindContractToBuilderMatchesImpl(contractTypes);
            dependencyRegistrator.RegisterBuildersImpl(contractToBuilderMatches.Values.Select(k => k).ToArray());
        }

        public static void RegisterBuilders(this IDependencyRegistrator dependencyRegistrator)
        {
            var assembliesProvider = new BuildersAssemblySourceProvider(PlatformProvider.Current.GetRootPath());
            var allAssemblies = assembliesProvider.Assemblies.ToArray();
            var buildersTypes = allAssemblies.FindBuildersTypes();
            dependencyRegistrator.RegisterBuildersImpl(buildersTypes);
        }

        internal static void RegisterBuildersImpl(this IDependencyRegistrator dependencyRegistrator, Type[] buildersTypes)
        {
            foreach (var type in buildersTypes)
            {
                var instance = BuilderFactory.CreateBuilderInstance(type);
                dependencyRegistrator.RegisterInstance(type, instance);
            }
        }
    }
}
