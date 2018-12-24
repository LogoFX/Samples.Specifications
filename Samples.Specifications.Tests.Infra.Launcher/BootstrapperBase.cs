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
    //TODO: Move to packages
    internal abstract class BootstrapperBase :
        IInitializable,
        IExtensible<BootstrapperBase>,        
        ICompositionModulesProvider,
        IAssemblySourceProvider,
        IHaveRegistrator
    {
        private ModularityAspect _modularityAspect;
        private DiscoveryAspect _discoveryAspect;
        private readonly ExtensibilityAspect<BootstrapperBase> _concreteExtensibilityAspect;        

        private readonly List<IAspect> _aspects = new List<IAspect>();

        protected BootstrapperBase(IDependencyRegistrator dependencyRegistrator) : this() =>
            Registrator = dependencyRegistrator;

        public IDependencyRegistrator Registrator { get; }

        private BootstrapperBase()
        {
            _concreteExtensibilityAspect = new ExtensibilityAspect<BootstrapperBase>(this);
        }

        public void Initialize()
        {
            void UseCoreAspects()
            {
                var aspects = new List<IAspect> {new PlatformAspect()};
                _modularityAspect = new ModularityAspect(new ModularityOptions
                {
                    ModulesPath = ModulesPath,
                    Prefixes = Prefixes
                });
                aspects.Add(_modularityAspect);
                _discoveryAspect = new DiscoveryAspect(_modularityAspect);
                aspects.Add(_discoveryAspect);                
                aspects.Add(_concreteExtensibilityAspect);
                //Instead of InsertRange() method
                aspects.Reverse();
                _aspects.Reverse();
                _aspects.AddRange(aspects);
                _aspects.Reverse();
            }
           
            UseCoreAspects();
            foreach (var aspect in _aspects)
            {
                aspect.Initialize();
            }
        }        

        public BootstrapperBase UseAspect(IAspect aspect)
        {
            _aspects.Add(aspect);
            return this;
        }

        IEnumerable<ICompositionModule> ICompositionModulesProvider<ICompositionModule>.Modules =>
            _modularityAspect.Modules;

        public BootstrapperBase Use(IMiddleware<BootstrapperBase> middleware)
        {
            return _concreteExtensibilityAspect.Use(middleware);
        }        

        IEnumerable<Assembly> IAssemblySourceProvider.Assemblies => _discoveryAspect.Assemblies;

        public virtual string[] Prefixes => new string[] {};
        public virtual string ModulesPath => ".";
    }
}