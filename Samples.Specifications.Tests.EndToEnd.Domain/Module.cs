using System.Reflection;
using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd.White;
using Samples.Specifications.Tests.Domain;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {            
            iocContainer.RegisterAutomagically(Assembly.LoadFrom("Samples.Specifications.Tests.Domain.dll"),
                Assembly.GetExecutingAssembly());
            iocContainer.RegisterSingleton<IExecutableContainer, ExecutableContainer>();
            iocContainer.RegisterSingleton<StructureHelper, StructureHelper>();
            iocContainer.RegisterSingleton<IStartApplicationHelper, StartApplicationHelper>();
        }
    }
}
