using Samples.Specifications.Tests.Domain;

namespace Samples.Specifications.Tests.Steps
{
    public class GeneralSteps
    {
        private readonly IStartClientApplicationService _startClientApplicationService;

        public GeneralSteps(IStartClientApplicationService startClientApplicationService)
        {
            _startClientApplicationService = startClientApplicationService;
        }

        public void WhenIOpenTheApplication()
        {
            _startClientApplicationService.StartApplication();
        }
    }
}
