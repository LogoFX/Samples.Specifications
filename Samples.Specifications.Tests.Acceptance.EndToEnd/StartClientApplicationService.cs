using System.IO;
using LogoFX.Client.Testing.Contracts;
using Samples.Specifications.Tests.Acceptance.Contracts;

namespace Samples.Specifications.Tests.Acceptance.EndToEnd
{
    class StartClientApplicationService : IStartClientApplicationService
    {
        private readonly IStartApplicationService _startApplicationService;

        public StartClientApplicationService(IStartApplicationService startApplicationService)
        {
            _startApplicationService = startApplicationService;
        }

        public void StartApplication()
        {
            var testDirectory = Directory.GetCurrentDirectory();
            var applicationDirectory = Directory.GetParent(testDirectory).FullName;
            var applicationPath = Path.Combine(applicationDirectory, "Samples.Specifications.Client.Launcher.exe");
            Directory.SetCurrentDirectory(applicationDirectory);
            _startApplicationService.StartApplication(applicationPath);
            Directory.SetCurrentDirectory(testDirectory);
        }
    }
}
