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
    class SpecFlowBridge : Attest.Tests.SpecFlow.EndToEndTestsBase
    {
        public SpecFlowBridge()
        {
            ScenarioHelper.Add(new StartApplicationService(), typeof(IStartApplicationService));
            ScenarioHelper.Add(new BuilderRegistrationService(), typeof(IBuilderRegistrationService));            
            ScenarioHelper.Add(new ShellScreenObject(), typeof(IShellScreenObject));            
        }

        protected override void OnAfterTeardown()
        {
            base.OnAfterTeardown();
            if (ApplicationContext.Application != null)
            {
                ApplicationContext.Application.Dispose();
            }
            ScenarioHelper.Clear();
        }
    }
}
