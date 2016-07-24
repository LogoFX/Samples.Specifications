using LogoFX.Client.Testing.Contracts;
using Samples.Specifications.Tests.Acceptance.Contracts;

namespace Samples.Specifications.Client.Tests.Integration
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
            _startApplicationService.StartApplication(string.Empty);
        }
    }
}
