using LogoFX.Client.Mvvm.ViewModel.Services;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Presentation.Shell
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterSingleton<IMessageService, DefaultMessageService>();
        }
    }
}
