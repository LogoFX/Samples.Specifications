using BoDi;
using Samples.Specifications.Tests.EndToEnd.Infra.Launcher;
using Solid.IoC.Adapters.ObjectContainer;
using Solid.Practices.IoC;
using TechTalk.SpecFlow;

namespace Samples.Specifications.Tests.Acceptance.Specs
{
    [Binding]
    sealed class LifecycleHook
    {
        private readonly IIocContainer _iocContainer;

        public LifecycleHook(ObjectContainer objectContainer)
        {
            _iocContainer = new ObjectContainerAdapter(objectContainer);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _iocContainer.Initialize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _iocContainer.Teardown();
        }
    }
}
