using System.IO;
using LogoFX.Client.Testing.Contracts;
using Samples.Specifications.Tests.Contracts;

namespace Samples.Specifications.Tests.EndToEnd
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
            //The SetCurrentDirectory() trick
            //is needed in both Fake and Real
            //In both cases it allows the app to correctly read its modules
            //as Solid.Composition uses Directory.GetCurrentDirectory() internally
            //to locate the root folder
            //In Fake case it also allows correct builder serialization location
            var testDirectory = Directory.GetCurrentDirectory();
            var applicationDirectory = Directory.GetParent(testDirectory).FullName;
            var applicationPath = Path.Combine(applicationDirectory, _applicationPathWrapper.Path);
            Directory.SetCurrentDirectory(applicationDirectory);
            _startApplicationService.StartApplication(applicationPath);
            Directory.SetCurrentDirectory(testDirectory);
        }
    }    
}
