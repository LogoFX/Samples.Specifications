using LogoFX.Client.Testing.Integration.SpecFlow;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;
using Samples.Specifications.Client.Tests.Integration.Infra.Shared;
using TechTalk.SpecFlow;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Specs
{
    /// <summary>
    /// Represents specflow bridge which creates the IoC container and invokes the bootstrapper
    /// </summary>
    [Binding]
    class SpecflowBridge :
        IntegrationTestsBase<ShellViewModel, TestBootstrapper>
    {                
        protected override void OnAfterTeardown()
        {
            base.OnAfterTeardown();
            TestHelper.AfterTeardown();
        }        
    }
}
