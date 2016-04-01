using LogoFX.Client.Mvvm.ViewModel.Services;

namespace LogoFX.Samples.Specifications.Client.Presentation.Shell
{
    partial class App
    {
        public App()
        {
            var bootstrapper = new AppBootstrapper();
            bootstrapper.UseViewModelCreatorService();
            bootstrapper.Initialize();
        }
    }
}
