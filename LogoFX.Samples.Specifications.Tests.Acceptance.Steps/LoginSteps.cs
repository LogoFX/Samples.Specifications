using Samples.Specifications.Tests.Acceptance.Contracts.ScreenObjects;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps
{
    public class LoginSteps
    {
        private readonly ILoginScreenObject _loginScreenObject;

        public LoginSteps(ILoginScreenObject loginScreenObject)
        {
            _loginScreenObject = loginScreenObject;
        }

        public void WhenISetTheUsernameTo(string username)
        {
            _loginScreenObject.SetUsername(username);
        }

        public void WhenISetThePasswordTo(string password)
        {
            _loginScreenObject.SetPassword(password);
        }

        public void WhenILogInToTheSystem()
        {
            _loginScreenObject.Login();
        }

        public void ThenTheLoginScreenIsDisplayed()
        {
           
        }
    }
}
