using Attest.Tests.Core;
using LogoFX.Client.Tests.Contracts;
using LogoFX.Client.Tests.EndToEnd;
using LogoFX.Client.Tests.EndToEnd.White;
using LogoFX.Samples.Specifications.Tests.Acceptance.ScreenObjects.Contracts;
using LogoFX.Samples.Specifications.Tests.Acceptance.ScreenObjects.EndToEnd;
using TechTalk.SpecFlow;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Infra.Bridge
{
    /// <summary>
    /// Represents SpecFlow bridge which performs the required registrations
    /// for screen objects and application services
    /// </summary>
    [Binding]
    class SpecFlowBridge : LogoFX.Client.Tests.SpecFlow.EndToEndTestsBase
    {
        protected override void RegisterScreenObjects()
        {
            base.RegisterScreenObjects();
            ScenarioHelper.Add(new ShellScreenObject(), typeof(IShellScreenObject));
            ScenarioHelper.Add(new MainScreenObject(), typeof(IMainScreenObject));
        }
    }
}
