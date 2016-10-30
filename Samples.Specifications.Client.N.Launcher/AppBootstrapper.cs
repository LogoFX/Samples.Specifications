using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;

namespace Samples.Specifications.Client.Launcher
{
    public class AppBootstrapper : BootstrapperContainerBase<ExtendedSimpleContainerAdapter>
    {
        public AppBootstrapper(ExtendedSimpleContainerAdapter containerAdapter) 
            : base(containerAdapter)
        {
        }       
    }
}
