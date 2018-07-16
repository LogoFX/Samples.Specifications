using Samples.Specifications.Tests.Domain;
using Solid.Practices.IoC;

namespace Samples.Specifications.Tests.Infra.Launcher
{
    public static class Extensions
    {
        public static void Initialize(this IIocContainer iocContainer)
        {
            new Startup(iocContainer).Initialize();
        }

        public static void Setup(this IIocContainer iocContainer)
        {
            var setupService = iocContainer.Resolve<ISetupService>();
            setupService.Setup();
        }
        
        public static void Teardown(this IIocContainer iocContainer)
        {
            var teardownService = iocContainer.Resolve<ITeardownService>();
            teardownService.Teardown();
        }
    }
}