using JetBrains.Annotations;
using LogoFX.Samples.Specifications.Client.Model.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace LogoFX.Samples.Specifications.Client.Model
{
    [UsedImplicitly]
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {            
            iocContainer.RegisterSingleton<IDataService, DataService>();
            iocContainer.RegisterSingleton<ILoginService, LoginService>();
        }
    }
}
