using BoDi;
using Samples.Specifications.Tests.Infra.Launcher;
using Solid.Common;
using Solid.IoC.Adapters.ObjectContainer;
using Solid.Practices.Composition;
using Solid.Practices.IoC;
using TechTalk.SpecFlow;

namespace Samples.Specifications.Tests.Acceptance.Specs
{
    [Binding]
    internal sealed class LifecycleHook
    {
        private readonly IIocContainer _iocContainer;

        public LifecycleHook(ObjectContainer objectContainer) => _iocContainer = new ObjectContainerAdapter(objectContainer);

        [BeforeTestRun]
        public static void BeforeAllScenarios()
        {
            PlatformProvider.Current = new NetStandardPlatformProvider();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _iocContainer.Initialize();
            _iocContainer.Setup();            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _iocContainer.Teardown();
        }
    }
}
