using Attest.Testing.Core;
using Solid.Bootstrapping;
using Solid.Core;
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
                .Use(new UseLifecycleMiddleware<Bootstrapper>());                                  
            bootstrapper.Initialize();
        }
    }
}
