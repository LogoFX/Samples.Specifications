using Samples.Specifications.Client.Tests.Integration.Infra.Shared;
using Samples.Specifications.Tests.Domain;

namespace Samples.Specifications.Client.Tests.Integration.Domain
{
    class SetupService : ISetupService
    {
#if REAL
        private readonly ISetupHelper _setupHelper;

        public SetupService(ISetupHelper setupHelper)
        {
            _setupHelper = setupHelper;
        }

        public void Setup()
        {
            _setupHelper.Initialize();
            SetupCore();
        }
#endif

#if FAKE        
        public void Setup()
        {      
            SetupCore();
        }
#endif

        private static void SetupCore()
        {
            LogoFX.Client.Testing.Shared.TestHelper.Setup();
        }
    }

    class TeardownService : ITeardownService
    {
        public void Teardown()
        {
            TestHelper.AfterTeardown();
        }
    }
}