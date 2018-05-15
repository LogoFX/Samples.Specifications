using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Mvvm.Commanding;
using Samples.Specifications.Client.Launcher.Shared;

namespace Samples.Specifications.Client.Launcher
{
    partial class App
    {
        public App()
        {
            
            var bootstrapper = new AppBootstrapper();
            var init = bootstrapper
                .UseResolver()
                .UseCommanding()
                .UseShared();

                init.Initialize();            
        }
    }
}
