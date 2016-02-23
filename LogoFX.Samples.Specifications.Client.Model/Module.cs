using System.Composition;
using LogoFX.Samples.Specifications.Client.Model.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace LogoFX.Samples.Specifications.Client.Model
{
    [Export(typeof(ICompositionModule))]
    class Module : ICompositionModule<IIocContainer>
    {
        public void RegisterModule(IIocContainer iocContainer)
        {            
            iocContainer.RegisterSingleton<IDataService, DataService>();
            iocContainer.RegisterSingleton<ILoginService, LoginService>();
        }
    }
}
