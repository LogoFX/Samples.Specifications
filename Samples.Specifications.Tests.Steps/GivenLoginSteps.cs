#if FAKE
using LogoFX.Client.Testing.Contracts;
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

        public void SetupAuthenticatedUserWithCredentials(string username, string password)
        {
#if FAKE
            _loginProviderBuilder.WithUser(username, password);
            _builderRegistrationService.RegisterBuilder(_loginProviderBuilder);
#endif

#if REAL
            var repository = new DbSetupHelper();
            //TODO: should be executed once and for all collections - not here of course
            repository.ClearUsers();
            repository.AddUser(username, password);

            //using (var storage = new Storage())
            //{
            //    storage.Store(new UserDto
            //    {
            //        Login = username,
            //        Password = password
            //    });
            //}
#endif
        }
    }
}
