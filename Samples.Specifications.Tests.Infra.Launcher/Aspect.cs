using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Solid.Bootstrapping;
using Solid.Common;
using Solid.Extensibility;
using Solid.Practices.Composition;
using Solid.Practices.Composition.Client;
using Solid.Practices.Composition.Container;
using Solid.Practices.Composition.Contracts;
using Solid.Practices.Middleware;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.Infra.Launcher
{
    //TODO: Move to packages
    public interface IAspect : IInitializable
    {
        string Id { get; }
    }

    public class ModularityOptions
    {
        public string ModulesPath { get; set; }
        public string[] Prefixes { get; set; }
    }

    public class ModularityAspect : IAspect, ICompositionModulesProvider
    {
        private readonly ModularityOptions _options;

        public ModularityAspect() :
            this(new ModularityOptions { ModulesPath = ".", Prefixes = new string[] { } })
        {

        }

        public ModularityAspect(ModularityOptions options)
        {
            _options = options;
        }

        public IEnumerable<ICompositionModule> Modules { get; private set; } = new ICompositionModule[] { };

        public string ModulesPath => _options.ModulesPath;

        public string[] Prefixes => _options.Prefixes;

        public void Initialize()
        {
            var compositionManager = new CompositionManager();
            try
            {
                compositionManager.Initialize(ModulesPath, Prefixes);
            }
#pragma warning disable 168 
            //Used for debug
            catch (AggregateAssemblyInspectionException ex)
#pragma warning restore 168
            {

            }
            finally
            {
                Modules = compositionManager.Modules.ToArray();
            }
        }

        public string Id => "Modularity";
    }

    public class PlatformAspect : IAspect
    {
        public void Initialize()
        {
            PlatformProvider.Current = new NetStandardPlatformProvider();
        }

        public string Id => "Platform";
    }

    public class ExtensibilityAspect<T> :
        IAspect,
        IExtensible<T> where T : class
    {
        private readonly T _bootstrapper;

        public ExtensibilityAspect(T bootstrapper)
        {
            _bootstrapper = bootstrapper;
            _middlewaresWrapper = new MiddlewaresWrapper<T>(_bootstrapper);
        }

        private readonly MiddlewaresWrapper<T> _middlewaresWrapper;

        /// <inheritdoc />       
        public T Use(
            IMiddleware<T> middleware)
        {
            _middlewaresWrapper.Use(middleware);
            return _bootstrapper;
        }

        public void Initialize()
        {
            MiddlewareApplier.ApplyMiddlewares(_bootstrapper, _middlewaresWrapper.Middlewares);
        }

        public string Id => $"Extensibility.{typeof(T).Name}";
    }

    public class DiscoveryAspect : IAspect, IAssemblySourceProvider
    {
        private readonly ModularityAspect _modularityAspect;

        public DiscoveryAspect(ModularityAspect modularityAspect)
        {
            _modularityAspect = modularityAspect;
        }

        public void Initialize()
        {
            GetAssemblies();
        }

        public string Id => "Discovery";

        private Assembly[] _assemblies;
        public IEnumerable<Assembly> Assemblies => _assemblies ?? (_assemblies = GetAssemblies());

        private Assembly[] GetAssemblies()
        {
            var assembliesResolver = new AssembliesResolver(GetType(),
                new CustomAssemblySourceProvider(PlatformProvider.Current.GetRootPath(),
                    _modularityAspect.Prefixes));
            return ((IAssembliesReadOnlyResolver)assembliesResolver).GetAssemblies().ToArray();
        }
    }
}
