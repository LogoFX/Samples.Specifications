using JetBrains.Annotations;
using Samples.Specifications.Client.Presentation.Shell.Contracts.ViewModels;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Presentation.Shell
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.RegisterSingleton<IShellViewModel, ShellViewModel>();
        }
    }
}
