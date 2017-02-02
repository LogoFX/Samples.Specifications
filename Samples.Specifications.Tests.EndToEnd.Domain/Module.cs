using System.Reflection;
using Samples.Specifications.Tests.Domain;
using Samples.Specifications.Tests.Domain.ScreenObjects;
using Samples.Specifications.Tests.EndToEnd.Domain.ScreenObjects;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            //iocContainer.RegisterSingleton<ILoginScreenObject, LoginScreenObject>();
            //iocContainer.RegisterSingleton<IShellScreenObject, ShellScreenObject>();
            //iocContainer.RegisterSingleton<IMainScreenObject, MainScreenObject>();
            //iocContainer.RegisterSingleton<IWarehouseScreenObject, WarehouseScreenObject>();
            //iocContainer.RegisterSingleton<IExitScreenObject, ExitScreenObject>();
            //iocContainer.RegisterSingleton<IStartClientApplicationService, StartClientApplicationService>();
            iocContainer.RegisterAutomagically(Assembly.LoadFrom("Samples.Specifications.Tests.Domain.dll"),
                Assembly.GetExecutingAssembly());
            iocContainer.RegisterSingleton<IExecutableContainer, ExecutableContainer>();
            iocContainer.RegisterSingleton<StructureHelper, StructureHelper>();
        }
    }
}
