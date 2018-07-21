#if FAKE
using Attest.Testing.Contracts;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;
#endif

#if REAL
using Samples.Specifications.Tests.Steps.Helpers;
#endif

namespace Samples.Specifications.Tests.Steps
{
    public class GivenLoginSteps
    {
#if FAKE
        private readonly IBuilderRegistrationService _builderRegistrationService;
        private readonly LoginProviderBuilder _loginProviderBuilder;

        public GivenLoginSteps(IBuilderRegistrationService builderRegistrationService, 
            LoginProviderBuilder loginProviderBuilder)
        {
            _builderRegistrationService = builderRegistrationService;
            _loginProviderBuilder = loginProviderBuilder;
        }
#endif
#if REAL
        private readonly ISetupHelper _setupHelper;

        public GivenLoginSteps(ISetupHelper setupHelper)
        {
            _setupHelper = setupHelper;
        }

#endif

        public void SetupAuthenticatedUserWithCredentials(string username, string password)
        {
#if FAKE
            _loginProviderBuilder.WithUser(username, password);
            _builderRegistrationService.RegisterBuilder(_loginProviderBuilder);
#endif

#if REAL                        
            _setupHelper.AddUser(username, password);            
#endif
        }
    }
}
