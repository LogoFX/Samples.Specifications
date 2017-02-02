using LogoFX.Bootstrapping;
using Solid.Practices.IoC;

namespace Samples.Specifications.Tests.EndToEnd.Infra.Launcher
{
    /// <summary>
    /// Represents SpecFlow bridge which performs the required registrations
    /// for screen objects and application services
    /// </summary>    
    class Startup
    {
        private readonly IIocContainer _iocContainer;

        public Startup(IIocContainer iocContainer)
        {
            _iocContainer = iocContainer;                   
        }

        public void Initialize()
        {
            var bootstrapper =
                new Bootstrapper(_iocContainer)
                    .Use(new RegisterCompositionModulesMiddleware<Bootstrapper>());                    
            bootstrapper.Initialize();
        }
    }
}
