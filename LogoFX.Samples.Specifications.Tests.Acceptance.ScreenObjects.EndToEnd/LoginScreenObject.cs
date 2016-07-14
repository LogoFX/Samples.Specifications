using LogoFX.Client.Testing.EndToEnd.White;
using LogoFX.Samples.Specifications.Tests.Acceptance.ScreenObjects.Contracts;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
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

        public void SetPassword(string password)
        {
            var loginScreen = GetLoginScreen();
            var passwordBox = loginScreen.Get(SearchCriteria.ByAutomationId("Login_Password"));
            passwordBox.Enter(password);
        }

        private Window GetLoginScreen()
        {
            var application = ApplicationContext.Application;
            var loginScreen = application.GetWindowEx("Login View");
            return loginScreen;
        }
    }
}
