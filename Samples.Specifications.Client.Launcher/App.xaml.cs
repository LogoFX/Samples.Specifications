using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Mvvm.Commanding;
using Samples.Specifications.Client.Launcher.Shared;

namespace Samples.Specifications.Client.Launcher
{
    partial class App
    {
        public App() => new AppBootstrapper()
                .UseResolver()
                .UseCommanding()
                .UseShared()
                .Initialize();
    }
}
