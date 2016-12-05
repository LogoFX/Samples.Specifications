using Caliburn.Micro;
using LogoFX.Client.Testing.Integration.xUnit;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;
using Samples.Specifications.Client.Tests.Integration.Infra.Shared;

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