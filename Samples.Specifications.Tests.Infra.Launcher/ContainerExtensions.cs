using Solid.Practices.IoC;

namespace Samples.Specifications.Tests.Infra.Launcher
{
    public static class ContainerExtensions
    {
        public static void Initialize(this IIocContainer iocContainer) =>
            new Startup(iocContainer).Initialize();        
    }
}