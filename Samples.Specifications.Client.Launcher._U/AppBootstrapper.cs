using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.Unity;
using LogoFX.Practices.IoC;
using Microsoft.Practices.Unity;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;

namespace Samples.Specifications.Client.Launcher
{
    public sealed class AppBootstrapper : BootstrapperContainerBase<UnityContainerAdapter, UnityContainer>
        .WithRootObject<ShellViewModel>
    {
        public AppBootstrapper()
            : base(new UnityContainer(), c => new UnityContainerAdapter())
        {
        }
    }
}
