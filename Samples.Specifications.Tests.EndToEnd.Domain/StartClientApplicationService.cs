using System.IO;
using LogoFX.Client.Testing.Contracts;
using Samples.Specifications.Tests.Domain;

namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    internal sealed class StartClientApplicationService : IStartClientApplicationService
    {        
        private readonly IStartApplicationService _startApplicationService;
        private readonly IExecutableWrapper _executableWrapper;

        public StartClientApplicationService(
            IStartApplicationService startApplicationService,
            IExecutableWrapper executableWrapper)
        {
            _startApplicationService = startApplicationService;
            _executableWrapper = executableWrapper;
        }

        public void StartApplication()
        {
            var testDirectory = Directory.GetCurrentDirectory();
            var applicationDirectory = Directory.GetParent(testDirectory).FullName;
            var applicationPath = Path.Combine(applicationDirectory, _executableWrapper.Path);
            Directory.SetCurrentDirectory(applicationDirectory);
            _startApplicationService.StartApplication(applicationPath);
            Directory.SetCurrentDirectory(testDirectory);
        }
    }    
}
