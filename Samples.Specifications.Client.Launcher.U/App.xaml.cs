using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.Unity;
using Samples.Specifications.Client.Launcher.Shared;

namespace Samples.Specifications.Client.Launcher
{
    partial class App
    {
        public App()
        {            
            var bootstrapper = new AppBootstrapper(new UnityContainerAdapter());
            bootstrapper.UseResolver().UseShared().Initialize();            
        }
    }
}
