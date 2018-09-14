using System;
using System.Threading;
using Samples.Specifications.Tests.Domain;
using Samples.Specifications.Tests.Domain.ScreenObjects;

namespace Samples.Specifications.Tests.Steps
{
    public class GeneralSteps
    {
        private readonly IStartClientApplicationService _startClientApplicationService;
        private readonly IShellScreenObject _shellScreenObject;

        public GeneralSteps(
            IStartClientApplicationService startClientApplicationService,
            IShellScreenObject shellScreenObject)
        {
            _startClientApplicationService = startClientApplicationService;
            _shellScreenObject = shellScreenObject;
        }

        public void WhenIOpenTheApplication()
        {
            _startClientApplicationService.StartApplication();
        }

        public void WhenICloseTheApplication()
        {
            _shellScreenObject.Close();
        }

        public void WaitFor(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }
    }
}
