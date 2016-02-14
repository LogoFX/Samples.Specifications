using LogoFX.Client.Tests.EndToEnd.White;
using LogoFX.Samples.Specifications.Tests.Acceptance.ScreenObjects.Contracts;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.ScreenObjects.EndToEnd
{
    public class LoginScreenObject : ILoginScreenObject
    {
        public void Login()
        {
            var loginScreen = GetLoginScreen();
            var loginButton = loginScreen.Get<Button>("Login_SignIn");
            loginButton.Click();            
        }

        public void SetUsername(string username)
        {
            var loginScreen = GetLoginScreen();
            var userNameTextBox = loginScreen.Get<TextBox>("Login_UserName");
            userNameTextBox.Enter(username);            
        }

        private Window GetLoginScreen()
        {
            var application = ApplicationContext.Application;
            var loginScreen =
                application.GetWindow("Login View");
            return loginScreen;
        }
    }
}
