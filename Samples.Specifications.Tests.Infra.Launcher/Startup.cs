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
                .Use(new ModulesRegistrationMiddleware<BootstrapperBase>())
                .Use(new RegisterResolverMiddleware<BootstrapperBase>(_iocContainer))
                .Use(new RegisterCollectionMiddleware<BootstrapperBase, IDynamicApplicationModule>())
                .Use(new RegisterCollectionMiddleware<BootstrapperBase, IStaticApplicationModule>())
                .Use(new RegisterCollectionMiddleware<BootstrapperBase, ISetupService>())
                .Use(new RegisterCollectionMiddleware<BootstrapperBase, ITeardownService>());        
            bootstrapper.Use(new UseApplicationModulesMiddleware());
            bootstrapper.Initialize();
        }
    }
}
