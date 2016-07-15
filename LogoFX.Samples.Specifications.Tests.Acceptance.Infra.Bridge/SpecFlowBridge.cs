using BoDi;
using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd.FakeData;
using LogoFX.Client.Testing.EndToEnd.White;
using LogoFX.Samples.Specifications.Tests.Acceptance.ScreenObjects.Contracts;
using LogoFX.Samples.Specifications.Tests.Acceptance.ScreenObjects.EndToEnd;
using LogoFX.Samples.Specifications.Tests.Acceptance.Steps;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;
using TechTalk.SpecFlow;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Infra.Bridge
{
    /// <summary>
    /// Represents SpecFlow bridge which performs the required registrations
    /// for screen objects and application services
    /// </summary>
    [Binding]
    class SpecFlowBridge :
#if FAKE
        LogoFX.Client.Testing.EndToEnd.SpecFlow.EndToEndTestsBase.WithFakeProviders
#endif

#if REAL
        LogoFX.Client.Testing.EndToEnd.SpecFlow.EndToEndTestsBase.WithRealProviders
#endif
    {
        public SpecFlowBridge(IObjectContainer objectContainer)
        {
#if FAKE
            objectContainer.RegisterInstanceAs(new StartApplicationService.WithFakeProviders(), typeof(IStartApplicationService));
            objectContainer.RegisterInstanceAs(new BuilderRegistrationService(), typeof(IBuilderRegistrationService));
#endif
#if REAL
            objectContainer.RegisterInstanceAs(new StartApplicationService.WithRealProviders(), typeof(IStartApplicationService));
#endif        
            objectContainer.RegisterInstanceAs(new LoginScreenObject(), typeof(ILoginScreenObject));
            objectContainer.RegisterInstanceAs(new ShellScreenObject(), typeof(IShellScreenObject));
            objectContainer.RegisterInstanceAs(new MainScreenObject(), typeof(IMainScreenObject));
            objectContainer.RegisterTypeAs<LoginSteps, LoginSteps>();
            objectContainer.RegisterTypeAs<MainSteps, MainSteps>();
            objectContainer.RegisterTypeAs<GivenLoginSteps, GivenLoginSteps>();
            objectContainer.RegisterTypeAs<GivenMainSteps, GivenMainSteps>();
            objectContainer.RegisterInstanceAs(LoginProviderBuilder.CreateBuilder());
            objectContainer.RegisterInstanceAs(WarehouseProviderBuilder.CreateBuilder());
        }
                       
    }
}
