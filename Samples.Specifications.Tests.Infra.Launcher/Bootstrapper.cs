using Solid.Bootstrapping;
using Solid.Extensibility;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;

namespace Samples.Specifications.Tests.Infra.Launcher
{
    internal sealed class Bootstrapper : BootstrapperBase, IExtensible<IHaveRegistrator>
    {              
        private readonly ExtensibilityAspect<IHaveRegistrator> _registratorExtensibilityAspect;        

        public Bootstrapper(IDependencyRegistrator dependencyRegistrator) : base(dependencyRegistrator)
        {
            _registratorExtensibilityAspect = new ExtensibilityAspect<IHaveRegistrator>(this);
            UseAspect(_registratorExtensibilityAspect);
        }                           

        public IHaveRegistrator Use(IMiddleware<IHaveRegistrator> middleware)
        {
            return _registratorExtensibilityAspect.Use(middleware);
        }        

        public override string[] Prefixes => new[]
        {
            "Samples.Specifications.Tests", "Samples.Specifications.Client.Tests",
            "Samples.Specifications.Tests.Steps", "Samples.Specifications.Tests.Infra"
        };
    }
}