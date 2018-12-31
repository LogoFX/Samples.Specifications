using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using Samples.Specifications.Client.Launcher.Shared;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;
using Solid.Practices.Composition;

namespace Samples.Specifications.Client.Launcher
{
    public sealed class AppBootstrapper : BootstrapperContainerBase<ExtendedSimpleContainerAdapter>
        .WithRootObject<ShellViewModel>
    {
        public AppBootstrapper()
            : base(new ExtendedSimpleContainerAdapter())
        {
        }

        public override CompositionOptions CompositionOptions => new CompositionOptions
        {
            Prefixes = Consts.Prefixes
        };
    }
}
