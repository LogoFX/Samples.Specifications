using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.Unity;
using LogoFX.Samples.Specifications.Client.Presentation.Shell.ViewModels;

namespace LogoFX.Samples.Specifications.Client.Presentation.Shell
{
    public class AppBootstrapper : BootstrapperContainerBase<ShellViewModel, UnityContainerAdapter>
    {
        public AppBootstrapper() 
            : base(new UnityContainerAdapter(), new BootstrapperContainerCreationOptions
            {
                DiscoverCompositionModules = true,
                InspectAssemblies = true,
                ReuseCompositionInformation = false,
                UseApplication = true
            })
        {
        }              
    }
}
