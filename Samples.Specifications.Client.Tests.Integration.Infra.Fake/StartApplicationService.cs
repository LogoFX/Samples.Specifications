﻿using Caliburn.Micro;
using LogoFX.Client.Testing.EndToEnd.FakeData.Shared;
using LogoFX.Client.Testing.Integration;
using LogoFX.Client.Testing.Integration.SpecFlow;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;
using Samples.Specifications.Client.Tests.Integration.Infra.Core;
using Samples.Specifications.Client.Tests.Integration.Infra.Shared;

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
            //TODO: Strictly speaking this is not an appropriate place
            //for root object initialization - need to rethink the whole initialization process
            //for integration tests which MUST initialize their root object after the arrange step
            // ReSharper disable once UnusedVariable - used to invoke bootstrapper initialization
            var bootstrapperBridge = new BootstrapperBridge();
            bootstrapperBridge.InitializeRootObject();
        }

        protected override void OnStart(object rootObject)
        {
            base.OnStart(rootObject);
            var shell = (ShellViewModel)rootObject;
            _structureHelper.SetRootObject(shell);
            ScreenExtensions.TryActivate(shell);
        }

        class BootstrapperBridge : IntegrationTestsBase<ShellViewModel, TestBootstrapper>.WithExplicitRootObjectCreation
        {

        }
    }
}
