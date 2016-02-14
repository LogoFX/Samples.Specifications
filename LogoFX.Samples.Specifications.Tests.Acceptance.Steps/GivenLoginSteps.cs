#if FAKE
using Attest.Tests.Core;
using LogoFX.Client.Tests.Contracts;
using LogoFX.Samples.Specifications.Client.Data.Fake.ProviderBuilders;
#endif

#if REAL
#endif

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps
{
    public static class GivenLoginSteps
    {
        public static void SetupAuthenticatedUserWithUsername(string username)
        {
#if FAKE
            var loginProviderBuilder = ScenarioHelper.GetOrCreate(LoginProviderBuilder.CreateBuilder);
            loginProviderBuilder.WithUser(username, string.Empty);
            ScenarioHelper.Get<IBuilderRegistrationService>().RegisterBuilder(loginProviderBuilder);
#endif

#if REAL
            //put here real Setup
#endif
        }

        public static void SetupLoginSuccessfullyWithUsername(string username)
        {
#if FAKE
            var loginProviderBuilder = ScenarioHelper.GetOrCreate(LoginProviderBuilder.CreateBuilder);
            loginProviderBuilder.WithSuccessfulLogin(username);
            ScenarioHelper.Get<IBuilderRegistrationService>().RegisterBuilder(loginProviderBuilder);
#endif

#if REAL
            //put here real Setup
#endif
        }
    }
}
