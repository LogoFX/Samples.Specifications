using System.Collections.Generic;
using System.Reflection;
using Attest.Testing.Bootstrapping;
using Attest.Testing.Core;
using Solid.Bootstrapping;
using Solid.Extensibility;
using Solid.Practices.Composition;
using Solid.Practices.Composition.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;

namespace Samples.Specifications.Tests.Infra.Launcher
{
    internal sealed class Bootstrapper :
        BootstrapperBase,
        IExtensible<Bootstrapper>,
        IExtensible<IHaveRegistrator>,
        IAssemblySourceProvider
    {
        private readonly ExtensibilityAspect<IHaveRegistrator> _registratorExtensibilityAspect;
        private readonly ExtensibilityAspect<Bootstrapper> _thisExtensibilityAspect;
        private readonly DiscoveryAspect _discoveryAspect;

        public Bootstrapper(IDependencyRegistrator dependencyRegistrator) : base(dependencyRegistrator)
        {
            _thisExtensibilityAspect = new ExtensibilityAspect<Bootstrapper>(this);
            UseAspect(_thisExtensibilityAspect);
            _registratorExtensibilityAspect = new ExtensibilityAspect<IHaveRegistrator>(this);
            UseAspect(_registratorExtensibilityAspect);
            _discoveryAspect = new DiscoveryAspect(CompositionOptions, GetType());
            UseAspect(_discoveryAspect);
        }

        public IHaveRegistrator Use(IMiddleware<IHaveRegistrator> middleware) => _registratorExtensibilityAspect.Use(middleware);

        public Bootstrapper Use(IMiddleware<Bootstrapper> middleware) => _thisExtensibilityAspect.Use(middleware);

        IEnumerable<Assembly> IAssemblySourceProvider.Assemblies => _discoveryAspect.Assemblies;

        public override CompositionOptions CompositionOptions => new CompositionOptions
        {
            Prefixes = new[]
                {"Samples.Specifications.Tests", "Samples.Specifications.Client.Tests",
                    "Samples.Specifications.Tests.Steps", "Samples.Specifications.Tests.Infra"}
        };
    }    
}