using Attest.Testing.Contracts;
using BoDi;
using JetBrains.Annotations;
using Samples.Specifications.Tests.Infra;
using Samples.Specifications.Tests.Infra.Launcher;
using Solid.Common;
using Solid.IoC.Adapters.ObjectContainer;
using Solid.Practices.IoC;
using TechTalk.SpecFlow;

namespace Samples.Specifications.Tests.Acceptance.Specs
{
    [Binding]
    internal sealed class LifecycleHook
    {
        private readonly IIocContainer _iocContainer;
        private static ILifecycleService _lifecycleService;

        public LifecycleHook(ObjectContainer objectContainer) => _iocContainer = new ObjectContainerAdapter(objectContainer);

        [BeforeTestRun, UsedImplicitly]
        public static void BeforeAllScenarios()
        {
            PlatformProvider.Current = new NetStandardPlatformProvider();
        }

        [BeforeScenario, UsedImplicitly]
        public void BeforeScenario()
        {
            _iocContainer.Initialize();
            _lifecycleService = _iocContainer.Resolve<ILifecycleService>();
            _lifecycleService.Setup();
            _iocContainer.Setup();            
        }

        [AfterScenario, UsedImplicitly]
        public void AfterScenario()
        {
            _iocContainer.Teardown();
        }

        [AfterTestRun, UsedImplicitly]
        public static void AfterAllScenarios()
        {
            _lifecycleService.Teardown();
        }
    }
}
