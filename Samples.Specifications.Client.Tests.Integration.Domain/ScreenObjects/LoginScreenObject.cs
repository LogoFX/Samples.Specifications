﻿using Samples.Specifications.Client.Tests.Integration.Infra.Core;
using Samples.Specifications.Tests.Domain.ScreenObjects;

namespace Samples.Specifications.Client.Tests.Integration.Domain.ScreenObjects
{
    class LoginScreenObject : ILoginScreenObject
    {
        public StructureHelper StructureHelper { get; }

        public LoginScreenObject(StructureHelper structureHelper)
        {
            StructureHelper = structureHelper;
        }

        public bool IsActive()
        {
            var loginViewModel = StructureHelper.GetLogin();
            return loginViewModel.IsActive;
        }

        public void SetUsername(string username)
        {
            var loginViewModel = StructureHelper.GetLogin();
            loginViewModel.UserName = username;
        }

        public void SetPassword(string password)
        {
            var loginViewModel = StructureHelper.GetLogin();
            loginViewModel.Password = password;
        }

        public void Login()
        {
            var loginViewModel = StructureHelper.GetLogin();
            loginViewModel.LoginCommand.Execute(null);
        }

        public string GetErrorMessage()
        {
            var loginViewModel = StructureHelper.GetLogin();
            return loginViewModel.LoginFailureCause;
        }
    }
}
