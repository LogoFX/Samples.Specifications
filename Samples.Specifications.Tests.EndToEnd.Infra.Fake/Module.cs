using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd.FakeData;
using LogoFX.Client.Testing.EndToEnd.White;
using Solid.Practices.Composition;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd.Infra.Fake
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {        
        private const string BuildersAssemblyEnding = "Fake.ProviderBuilders";

        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterInstance<IStartApplicationService>(new StartApplicationService.WithFakeProviders());
            iocContainer.RegisterInstance<IBuilderRegistrationService>(new BuilderRegistrationService());
            const string builderEnding = "Builder";            
            var assembliesProvider = new BuildersAssemblySourceProvider(PlatformProvider.Current.GetRootPath());
            var allAssemblies = assembliesProvider.Assemblies.ToArray();           
            var buildersAssemblies = allAssemblies.Where(t => t.GetName().Name.EndsWith(BuildersAssemblyEnding));
            var matchingBuildersTypes = buildersAssemblies.SelectMany(k => k.DefinedTypes
                .Where(t => t.IsInterface == false && t.IsAbstract == false && t.Name.EndsWith(builderEnding))
                .Select(t => t.AsType())).ToArray();
            const string methodName = "CreateBuilder";
            var typeMatches = new Dictionary<Type, Type>();
            foreach (var type in matchingBuildersTypes)
            {
                var instance = type.GetRuntimeMethod(methodName, new Type[] { }).Invoke(null, null);
                iocContainer.RegisterInstance(type, instance);
            }          
        }

        public class BuildersAssemblySourceProvider : AssemblySourceProviderBase
        {
            public BuildersAssemblySourceProvider(string rootPath) : base(rootPath)
            {
            }

            protected override string[] ResolveNamespaces()
            {
                return new[] { BuildersAssemblyEnding };
            }
        }
    }
}
