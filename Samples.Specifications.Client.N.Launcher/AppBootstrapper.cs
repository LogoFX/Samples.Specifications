using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using Samples.Specifications.Client.Presentation.NavigationShell.ViewModels;

namespace Samples.Specifications.Client.Launcher
{
    public class AppBootstrapper : BootstrapperContainerBase<ExtendedSimpleContainerAdapter>
        .WithRootObject<NavigationShellViewModel>
    {
        public AppBootstrapper(ExtendedSimpleContainerAdapter containerAdapter) 
            : base(containerAdapter)
        {
        }       
    }
}
