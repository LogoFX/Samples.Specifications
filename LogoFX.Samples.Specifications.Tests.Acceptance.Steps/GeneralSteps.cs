using System.IO;
using Attest.Tests.Core;
using LogoFX.Client.Tests.Contracts;
using NUnit.Framework;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps
{
    public static class GeneralSteps
    {
        private static readonly IStartApplicationService _startApplicationService =
            ScenarioHelper.Get<IStartApplicationService>();

        public static void WhenIOpenTheApplication()
        {
            var applicationDirectory = TestContext.CurrentContext.TestDirectory;
            var applicationPath = Path.Combine(applicationDirectory, "LogoFX.Samples.Client.Presentation.Shell.exe");
            _startApplicationService.StartApplication(applicationPath);
        }
    }
}
