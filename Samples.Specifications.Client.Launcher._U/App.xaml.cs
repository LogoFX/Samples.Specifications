using LogoFX.Client.Bootstrapping;
using Samples.Specifications.Client.Launcher.Shared;

namespace Samples.Specifications.Client.Launcher
{
    partial class App
    {
        public App()
        {            
            var bootstrapper = new AppBootstrapper();
            bootstrapper.UseResolver();
            bootstrapper.UseShared().Initialize();
        }
    }
}
