using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;

namespace Samples.Specifications.Client.Launcher
{
    public class AppBootstrapper : BootstrapperContainerBase<ExtendedSimpleContainerAdapter>.WithRootObject<ShellViewModel>
    {
        public AppBootstrapper(ExtendedSimpleContainerAdapter containerAdapter) 
            : base(containerAdapter)
        {
        }              
    }
}
