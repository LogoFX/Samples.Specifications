using Attest.Testing.Bootstrapping;
using Solid.Bootstrapping;
using Solid.Extensibility;
using Solid.Practices.Composition;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;

namespace Samples.Specifications.Tests.Infra.Launcher
{
    internal sealed class Bootstrapper :
        BootstrapperBase,
        IExtensible<Bootstrapper>,
        IExtensible<IHaveRegistrator>
    {
        private readonly ExtensibilityAspect<IHaveRegistrator> _registratorExtensibilityAspect;
        private readonly ExtensibilityAspect<Bootstrapper> _thisExtensibilityAspect;        

        public Bootstrapper(IDependencyRegistrator dependencyRegistrator) : base(dependencyRegistrator)
        {
            _thisExtensibilityAspect = new ExtensibilityAspect<Bootstrapper>(this);
            UseAspect(_thisExtensibilityAspect);
            _registratorExtensibilityAspect = new ExtensibilityAspect<IHaveRegistrator>(this);
            UseAspect(_registratorExtensibilityAspect);           
        }

        public IHaveRegistrator Use(IMiddleware<IHaveRegistrator> middleware) => _registratorExtensibilityAspect.Use(middleware);

        public Bootstrapper Use(IMiddleware<Bootstrapper> middleware) => _thisExtensibilityAspect.Use(middleware);        

        public override CompositionOptions CompositionOptions => new CompositionOptions
        {
            Prefixes = new[]
                {"Samples.Specifications.Tests", "Samples.Specifications.Client.Tests",
                    "Samples.Specifications.Tests.Steps", "Samples.Specifications.Tests.Infra"}
        };
    }    
}