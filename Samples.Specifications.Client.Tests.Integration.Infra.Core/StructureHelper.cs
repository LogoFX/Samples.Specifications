using Samples.Specifications.Client.Presentation.Shell.Contracts.ViewModels;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Core
{
    /// <summary>
    /// Represents structure helper which provides easier API for accessing different parts of application
    /// </summary>
    public sealed class StructureHelper
    {
        private IShellViewModel _rootObject;

        /// <summary>
        /// Sets the root object which is the shell view model.
        /// </summary>
        /// <param name="rootObject">The root object.</param>
        public void SetRootObject(IShellViewModel rootObject) => _rootObject = rootObject;

        /// <summary>
        /// Gets the shell view model.
        /// </summary>
        /// <returns>Shell view model</returns>
        public IShellViewModel GetShell() => GetShellInternal();

        public ILoginViewModel GetLogin() => GetShellInternal()?.LoginViewModel;

        public IMainViewModel GetMain() => GetShellInternal()?.MainViewModel;

        private IShellViewModel GetShellInternal() => _rootObject;
    }
}
