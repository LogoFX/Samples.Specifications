using LogoFX.Bootstrapping;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Infra.Bridge
{
    public class RegisterCompositionModulesMiddleware<TIocContainer> : IMiddleware<Bootstrapper<TIocContainer>> 
        where TIocContainer : class, IIocContainerRegistrator
    {
        /// <summary>Applies the middleware on the specified object.</summary>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public Bootstrapper<TIocContainer> Apply(Bootstrapper<TIocContainer> @object)
        {
            @object.Container.RegisterContainerCompositionModules(@object.Modules);
            return @object;
        }
    }
}