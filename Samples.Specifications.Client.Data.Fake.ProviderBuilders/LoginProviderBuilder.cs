using System;
using System.Collections.Generic;
using Attest.Fake.Builders;
using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;
using Samples.Client.Data.Contracts.Providers;

namespace Samples.Specifications.Client.Data.Fake.ProviderBuilders
{
    public sealed class LoginProviderBuilder : FakeBuilderBase<ILoginProvider>.WithInitialSetup
    {
        private readonly Dictionary<string, string> _users = new Dictionary<string, string>();

        private LoginProviderBuilder()
        {

        }

        public static LoginProviderBuilder CreateBuilder() => new LoginProviderBuilder();

        public void WithUser(string username, string password) => _users.Add(username, password);

        protected override IServiceCall<ILoginProvider> CreateServiceCall(
            IHaveNoMethods<ILoginProvider> serviceCallTemplate) => serviceCallTemplate
            .AddMethodCall<string, string>(t => t.Login(It.IsAny<string>(), It.IsAny<string>()),
                (r, login, password) => _users.ContainsKey(login)
                    ? _users[login] == password
                        ? r.Complete()
                        : r.Throw(new Exception("Unable to login."))
                    : r.Throw(new Exception("Login not found.")));
    }
}