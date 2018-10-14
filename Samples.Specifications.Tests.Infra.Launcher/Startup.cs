using Solid.Bootstrapping;
using Solid.Practices.Composition.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.Infra.Launcher
{
    internal sealed class Startup
    {
        private readonly IDependencyRegistrator _dependencyRegistrator;

        public Startup(IDependencyRegistrator dependencyRegistrator) => _dependencyRegistrator = dependencyRegistrator;

        public void Initialize() => new Bootstrapper(_dependencyRegistrator)
            .Use(new ModulesRegistrationMiddleware<Bootstrapper>()).Initialize();

        private sealed class ModulesRegistrationMiddleware<TBootstrapper> : IMiddleware<TBootstrapper>
            where TBootstrapper : class, ICompositionModulesProvider, IHaveRegistrator
        {
            public TBootstrapper Apply(TBootstrapper @object)
            {
                var middlewares = new[]
                {
                    new ContainerRegistrationMiddleware<IDependencyRegistrator, IDependencyRegistrator>(@object.Modules)
                };
                MiddlewareApplier.ApplyMiddlewares(@object.Registrator, middlewares);
                return @object;
            }
        }
    }
}
