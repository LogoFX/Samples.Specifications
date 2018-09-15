using LogoFX.Client.Testing.Contracts;
using Samples.Specifications.Tests.Domain;

namespace Samples.Specifications.Client.Tests.Integration.Domain
{
    internal sealed class StartClientApplicationService : IStartClientApplicationService
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
