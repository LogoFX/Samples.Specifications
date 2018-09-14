using Attest.Testing.Contracts;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;

namespace Samples.Specifications.Tests.Steps
{
    internal sealed class GivenLoginSteps : IGivenLoginSteps
    {
        private readonly IBuilderRegistrationService _builderRegistrationService;
        private readonly LoginProviderBuilder _loginProviderBuilder;

        public GivenLoginSteps(IBuilderRegistrationService builderRegistrationService, 
            LoginProviderBuilder loginProviderBuilder)
        {
            _builderRegistrationService = builderRegistrationService;
            _loginProviderBuilder = loginProviderBuilder;
        }

        public void SetupAuthenticatedUserWithCredentials(string username, string password)
        {
            _loginProviderBuilder.WithUser(username, password);
            _builderRegistrationService.RegisterBuilder(_loginProviderBuilder);
        }
    }
}
