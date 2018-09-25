using System.IO;
using LogoFX.Client.Testing.Contracts;
using Samples.Specifications.Tests.Domain;

namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    internal sealed class StartClientApplicationService : IStartClientApplicationService
    {        
        private readonly IStartApplicationService _startApplicationService;
        private readonly IApplicationPathWrapper _applicationPathWrapper;

        public StartClientApplicationService(
            IStartApplicationService startApplicationService,
            IApplicationPathWrapper applicationPathWrapper)
        {
            _startApplicationService = startApplicationService;
            _applicationPathWrapper = applicationPathWrapper;
        }

        public void StartApplication()
        {
            var testDirectory = Directory.GetCurrentDirectory();
            var applicationDirectory = Directory.GetParent(testDirectory).FullName;
            var applicationPath = Path.Combine(applicationDirectory, _applicationPathWrapper.Path);
            Directory.SetCurrentDirectory(applicationDirectory);
            _startApplicationService.StartApplication(applicationPath);
            Directory.SetCurrentDirectory(testDirectory);
        }
    }    
}
