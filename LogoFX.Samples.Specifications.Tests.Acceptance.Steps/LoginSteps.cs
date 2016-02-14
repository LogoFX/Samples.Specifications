using Attest.Tests.Core;
using LogoFX.Samples.Specifications.Tests.Acceptance.ScreenObjects.Contracts;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps
{
    public static class LoginSteps
    {
        private static readonly ILoginScreenObject _loginScreenObject = ScenarioHelper.Get<ILoginScreenObject>();

        public static void WhenISetTheUsernameTo(string username)
        {
            _loginScreenObject.SetUsername(username);
        }

        public static void WhenILogInToTheSystem()
        {
            _loginScreenObject.Login();
        }

        public static void ThenTheLoginScreenIsDisplayed()
        {
           
        }
    }
}
