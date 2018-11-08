using System;
using System.Threading;
using Attest.Testing.Contracts;
using Samples.Specifications.Tests.Contracts.ScreenObjects;

namespace Samples.Specifications.Tests.Steps
{
    public sealed class GeneralSteps
    {
        private readonly IStartLocalApplicationService _startLocalApplicationService;
        private readonly IShellScreenObject _shellScreenObject;

        public GeneralSteps(
            IStartLocalApplicationService startLocalApplicationService,
            IShellScreenObject shellScreenObject)
        {
            _startLocalApplicationService = startLocalApplicationService;
            _shellScreenObject = shellScreenObject;
        }

        public void WhenIOpenTheApplication()
        {
            _startLocalApplicationService.Start();
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
