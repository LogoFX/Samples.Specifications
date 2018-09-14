using FluentAssertions;
using Samples.Specifications.Tests.Domain.ScreenObjects;

namespace Samples.Specifications.Tests.Steps
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

        public void ThenLoginErrorMessageIsDisplayedWithTheFollowingText(string errorMessage)
        {            
            var actualErrorMessage = _loginScreenObject.GetErrorMessage();
            actualErrorMessage.Should().Be(errorMessage);
        }       
    }
}
