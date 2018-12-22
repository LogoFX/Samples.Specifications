using System.Collections.Generic;
using System.Reflection;
using Solid.Bootstrapping;
using Solid.Extensibility;
using Solid.Practices.Composition.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.Infra.Launcher
{
    internal sealed class Bootstrapper :
        IInitializable,
        IExtensible<Bootstrapper>,
        IExtensible<IHaveRegistrator>,
        ICompositionModulesProvider,
        IAssemblySourceProvider,
        IHaveRegistrator
    {
        private readonly ModularityAspect _modularityAspect = new ModularityAspect(new ModularityOptions
        {
            Prefixes = new[]
            {
                "Samples.Specifications.Tests", "Samples.Specifications.Client.Tests",
                "Samples.Specifications.Tests.Steps"
            },
            ModulesPath = "."
        });

        private readonly DiscoveryAspect _discoveryAspect;
        private readonly ExtensibilityAspect<Bootstrapper> _concreteExtensibilityAspect;
        private readonly ExtensibilityAspect<IHaveRegistrator> _registratorExtensibilityAspect;

        private readonly List<IAspect> _aspects = new List<IAspect>();

        public Bootstrapper(IDependencyRegistrator dependencyRegistrator) : this() =>
            Registrator = dependencyRegistrator;

        public IDependencyRegistrator Registrator { get; }

        private Bootstrapper()
        {
            _aspects.Add(new PlatformAspect());
            _aspects.Add(_modularityAspect);
            _discoveryAspect = new DiscoveryAspect(_modularityAspect);
            _aspects.Add(_discoveryAspect);
            _concreteExtensibilityAspect = new ExtensibilityAspect<Bootstrapper>(this);
            _aspects.Add(_concreteExtensibilityAspect);
            _registratorExtensibilityAspect = new ExtensibilityAspect<IHaveRegistrator>(this);
            _aspects.Add(_registratorExtensibilityAspect);
        }

        public void Initialize()
        {
            foreach (var aspect in _aspects)
            {
                aspect.Initialize();
            }
        }

        public Bootstrapper UseAspect(IAspect aspect)
        {
            _aspects.Add(aspect);
            return this;
        }

        IEnumerable<ICompositionModule> ICompositionModulesProvider<ICompositionModule>.Modules =>
            _modularityAspect.Modules;

        public Bootstrapper Use(IMiddleware<Bootstrapper> middleware)
        {
            return _concreteExtensibilityAspect.Use(middleware);
        }

        public IHaveRegistrator Use(IMiddleware<IHaveRegistrator> middleware)
        {
            return _registratorExtensibilityAspect.Use(middleware);
        }

        IEnumerable<Assembly> IAssemblySourceProvider.Assemblies => _discoveryAspect.Assemblies;
    }
}