using LogoFX.Client.Testing.Integration.SpecFlow;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;
using Samples.Specifications.Client.Tests.Integration.Infra.Shared;
using TechTalk.SpecFlow;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Specs
{
    //TODO: not used right now - consider removing
    /// <summary>
    /// Represents specflow bridge which creates the IoC container and invokes the bootstrapper
    /// </summary>
    [Binding]
    public class SpecflowBridge :
        IntegrationTestsBase<ShellViewModel, TestBootstrapper>
    {
        [AfterScenario]
        protected override void OnAfterTeardown()
        {
            TestHelper.AfterTeardown();
        }        
    }
}
