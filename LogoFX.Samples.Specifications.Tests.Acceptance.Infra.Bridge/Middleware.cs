using LogoFX.Bootstrapping;
using Solid.Practices.Middleware;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Infra.Bridge
{
    public class RegisterCompositionModulesMiddleware : IMiddleware<Bootstrapper>
    {
        /// <summary>Applies the middleware on the specified object.</summary>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public Bootstrapper Apply(Bootstrapper @object)
        {
            @object.Container.RegisterContainerCompositionModules(@object.Modules);
            return @object;
        }
    }
}