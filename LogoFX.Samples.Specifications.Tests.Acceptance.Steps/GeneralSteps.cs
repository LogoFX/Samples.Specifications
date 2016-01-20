using System;
using System.IO;
using Attest.Tests.Core;
using LogoFX.Client.Tests.Contracts;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps
{
    public static class GeneralSteps
    {
        private static readonly IStartApplicationService _startApplicationService =
            ScenarioHelper.Get<IStartApplicationService>();

        public static void WhenIOpenTheApplication()
        {
            var applicationDirectory = Environment.CurrentDirectory;
            var applicationPath = Path.Combine(applicationDirectory, "LogoFX.Samples.Specifications.Client.Presentation.Shell.exe");
            _startApplicationService.StartApplication(applicationPath);            
        }
    }
}
