using Attest.Testing.Contracts;
using Solid.Bootstrapping;
using Solid.Practices.IoC;

namespace Samples.Specifications.Tests.Infra.Launcher
{
    internal sealed class Startup : IInitializable
    {
        private readonly IIocContainer _iocContainer;

        public Startup(IIocContainer iocContainer)
        {
            _iocContainer = iocContainer;
        }

        public void Initialize()
        {
            var bootstrapper = new Bootstrapper(_iocContainer);
            bootstrapper
                .Use(new ModulesRegistrationMiddleware<Bootstrapper>())
                .Use(new RegisterResolverMiddleware<Bootstrapper>(_iocContainer))
                .Use(new RegisterCollectionMiddleware<Bootstrapper, IDynamicApplicationModule>())
                .Use(new RegisterCollectionMiddleware<Bootstrapper, IStaticApplicationModule>())
                .Use(new RegisterCollectionMiddleware<Bootstrapper, ITeardownService>());
            bootstrapper.Use(new UseApplicationModulesMiddleware());
            bootstrapper.Initialize();
        }
    }
}
