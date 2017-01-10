using Caliburn.Micro;
using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.Integration;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;
using Samples.Specifications.Client.Tests.Integration.Infra.Core;

namespace Samples.Specifications.Client.Tests.Integration.Infra
{
    public class StartApplicationService : StartApplicationServiceBase
    {
        public StructureHelper StructureHelper { get; set; }
        private readonly IBuilderRegistrationService _builderRegistrationService;
        private readonly LoginProviderBuilder _loginProviderBuilder;
        private readonly WarehouseProviderBuilder _warehouseProviderBuilder;
        private readonly EventsProviderBuilder _eventsProviderBuilder;

        public StartApplicationService(
            IBuilderRegistrationService builderRegistrationService, 
            LoginProviderBuilder loginProviderBuilder,
            WarehouseProviderBuilder warehouseProviderBuilder,
            EventsProviderBuilder eventsProviderBuilder,
            StructureHelper structureHelper)
        {
            StructureHelper = structureHelper;
            _builderRegistrationService = builderRegistrationService;
            _loginProviderBuilder = loginProviderBuilder;
            _warehouseProviderBuilder = warehouseProviderBuilder;
            _eventsProviderBuilder = eventsProviderBuilder;
        }

        // ReSharper disable once RedundantOverridenMember
        protected override void RegisterFakes()
        {
            base.RegisterFakes();
            _builderRegistrationService.RegisterBuilder(_loginProviderBuilder);
            _builderRegistrationService.RegisterBuilder(_warehouseProviderBuilder);            
            _builderRegistrationService.RegisterBuilder(_eventsProviderBuilder);
        }

        protected override void OnStart(object rootObject)
        {
            var shell = (ShellViewModel)rootObject;
            StructureHelper.SetRootObject(shell);
            ScreenExtensions.TryActivate(shell);            
        }
    }
}