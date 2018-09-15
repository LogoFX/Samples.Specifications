﻿using LogoFX.Client.Testing.Integration.SpecFlow;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;
using Samples.Specifications.Client.Tests.Integration.Infra.Core;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Shared
{
    public abstract class StartApplicationServiceBase : LogoFX.Client.Testing.Integration.StartApplicationServiceBase
    {
        private readonly StructureHelper _structureHelper;

        protected StartApplicationServiceBase(StructureHelper structureHelper)
        {
            _structureHelper = structureHelper;
        }

        protected override void Setup()
        {
            base.Setup();
            OnArrange();
            //TODO: Strictly speaking this is not an appropriate place
            //for root object initialization - need to rethink the whole initialization process
            //for integration tests which MUST initialize their root object after the arrange step
            var bootstrapperBridge = new BootstrapperBridge();
            bootstrapperBridge.InitializeRootObject();
            SetupCore();
        }

        protected virtual void OnArrange()
        {
            
        }

        private static void SetupCore()
        {
            LogoFX.Client.Testing.Shared.TestHelper.Setup();
        }

        protected override void OnStart(object rootObject)
        {
            base.OnStart(rootObject);
            RootObjectHelper.InitializeRootObject(_structureHelper, rootObject);
        }

        private sealed class BootstrapperBridge : IntegrationTestsBase<ShellViewModel, TestBootstrapper.SpecBased>.
            WithExplicitRootObjectCreation
        {

        }
    }
}
