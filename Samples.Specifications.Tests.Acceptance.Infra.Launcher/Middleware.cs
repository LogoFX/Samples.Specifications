using LogoFX.Bootstrapping;
using Solid.Bootstrapping;
using Solid.Practices.Composition.Contracts;
using Solid.Practices.Middleware;

namespace Samples.Specifications.Tests.Acceptance.Infra.Launcher
{
    public class RegisterCompositionModulesMiddleware<TBootstrapper> : IMiddleware<TBootstrapper> 
        where TBootstrapper : class, ICompositionModulesProvider, IHaveContainerRegistrator
    {
        /// <summary>Applies the middleware on the specified object.</summary>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public TBootstrapper Apply(TBootstrapper @object)
        {
            @object.Registrator.RegisterContainerCompositionModules(@object.Modules);
            return @object;
        }
    }
}