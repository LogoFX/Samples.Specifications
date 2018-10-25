using Caliburn.Micro;
using LogoFX.Client.Testing.Integration.SpecFlow;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;
using Samples.Specifications.Client.Tests.Integration.Infra.Core;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Shared
{
    public abstract class StartApplicationServiceBase : Attest.Testing.Integration.StartApplicationServiceBase
    {
        private readonly StructureHelper _structureHelper;

        protected StartApplicationServiceBase(StructureHelper structureHelper) => _structureHelper = structureHelper;

        protected override void Setup()
        {
            base.Setup();
            OnArrange();
            //TODO: Strictly speaking this is not an appropriate place
            //for root object initialization - need to rethink the whole initialization process
            //for integration tests which MUST initialize their root object after the arrange step
            var bootstrapperBridge = new BootstrapperBridge();
            bootstrapperBridge.InitializeRootObject();
            LogoFX.Client.Testing.Shared.TestHelper.Setup();
        }

        protected virtual void OnArrange()
        {
            
        }        

        protected override void OnStart(object rootObject)
        {
            base.OnStart(rootObject);
            ActivateRootObject(_structureHelper, rootObject);
        }

        private static void ActivateRootObject(StructureHelper structureHelper, object rootObject)
        {
            var shell = (ShellViewModel)rootObject;
            structureHelper.SetRootObject(shell);
            ScreenExtensions.TryActivate(shell);
        }

        private sealed class BootstrapperBridge : IntegrationTestsBase<ShellViewModel, TestBootstrapper>.
            WithExplicitRootObjectCreation
        {

        }
    }
}
