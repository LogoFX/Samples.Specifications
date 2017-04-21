using System;
using LogoFX.Client.Testing.EndToEnd.White;
using Samples.Specifications.Tests.Domain.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Samples.Specifications.Tests.EndToEnd.Domain.ScreenObjects
{
    class LoginScreenObject : ILoginScreenObject
    {
        public void Login()
        {
            var loginScreen = GetLoginScreen();
            var loginButton = loginScreen.Get<Button>("Login_SignIn");
            loginButton.Click();
            //Action waitUntilNotBusy = () =>
            //{
            //    var isBusy = loginScreen.Get<Label>("Login_Busy");
            //    if (isBusy.Text == "True")
            //    {
            //        throw new Exception();
            //    }
            //};
            //waitUntilNotBusy.Execute();
        }

        public void SetUsername(string username)
        {
            var loginScreen = GetLoginScreen();
            for (int i = 0; i < 3; i++)
            {
                var userNameTextBox = loginScreen.Get<TextBox>("Login_UserName");
                userNameTextBox.Enter(username);
                if (userNameTextBox.Text == username)
                {
                    break;
                }
            }            
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

        public string GetErrorMessage()
        {
            var loginScreen = GetLoginScreen();
            var errorLabel = loginScreen.Get<Label>(SearchCriteria.ByAutomationId("Login_FailureTextBlock"));
            return errorLabel.Text;
        }
    }
}
