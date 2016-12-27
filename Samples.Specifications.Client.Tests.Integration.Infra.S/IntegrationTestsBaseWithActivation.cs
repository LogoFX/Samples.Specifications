using Caliburn.Micro;
using LogoFX.Client.Testing.Integration.xUnit;
using LogoFX.Client.Testing.Shared;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;

namespace Samples.Specifications.Client.Tests.Integration.Infra
{
    public abstract class IntegrationTestsBaseWithActivation :
        IntegrationTestsBase<ShellViewModel, TestBootstrapper>
    {               
        protected override ShellViewModel CreateRootObjectOverride(ShellViewModel rootObject)
        {
            ScreenExtensions.TryActivate(rootObject);
            return rootObject;
        }        

        protected override void OnBeforeTeardown()
        {
            base.OnBeforeTeardown();
            TestHelper.BeforeTeardown();
        }

        protected override void OnAfterTeardown()
        {
            base.OnAfterTeardown();
            TestHelper.AfterTeardown();
        }
    }
}