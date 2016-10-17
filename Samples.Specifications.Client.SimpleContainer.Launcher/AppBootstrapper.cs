using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;

namespace Samples.Specifications.Client.Launcher
{
    public class AppBootstrapper : BootstrapperContainerBase<SimpleContainerAdapter>.WithRootObject<ShellViewModel>
    {
        public AppBootstrapper(SimpleContainerAdapter containerAdapter) 
            : base(containerAdapter)
        {
        }              
    }
}
