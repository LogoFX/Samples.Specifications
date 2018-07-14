using Caliburn.Micro;
using LogoFX.Client.Testing.EndToEnd.FakeData.Shared;
using LogoFX.Client.Testing.Integration;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;
using Samples.Specifications.Client.Tests.Integration.Infra.Core;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Fake
{
    class StartApplicationService : StartApplicationServiceBase
    {
        private readonly StructureHelper _structureHelper;

        public StartApplicationService(StructureHelper structureHelper)
        {
            _structureHelper = structureHelper;
        }

        protected override void RegisterFakes()
        {
            base.RegisterFakes();
            BuildersCollectionContext.SerializeBuilders();
        }

        protected override void OnStart(object rootObject)
        {
            base.OnStart(rootObject);
            var shell = (ShellViewModel)rootObject;
            _structureHelper.SetRootObject(shell);
            ScreenExtensions.TryActivate(shell);
        }
    }
}
