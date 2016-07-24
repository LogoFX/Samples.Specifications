﻿using Samples.Specifications.Client.Tests.Integration.Infra.Core;
using Samples.Specifications.Tests.Acceptance.Contracts.ScreenObjects;

namespace Samples.Specifications.Client.Tests.Integration.ScreenObjects
{
    public class LoginScreenObject : ILoginScreenObject
    {
        public StructureHelper StructureHelper { get; set; }

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
    }
}