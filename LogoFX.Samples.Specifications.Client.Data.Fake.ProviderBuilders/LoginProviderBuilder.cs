using System;
using System.Collections.Generic;
using Attest.Fake.Moq;
using Attest.Fake.Setup;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Providers;

namespace LogoFX.Samples.Specifications.Client.Data.Fake.ProviderBuilders
{
    [Serializable]
    public class LoginProviderBuilder : BuilderBase<ILoginProvider>
    {        
        private readonly List<Tuple<string, string>> _users = new List<Tuple<string, string>>();
        private readonly Dictionary<string, bool> _isLoginAttemptSuccessfulCollection = new Dictionary<string, bool>();
        
        private LoginProviderBuilder()
        {

        }

        public static LoginProviderBuilder CreateBuilder()
        {
            return new LoginProviderBuilder();
        }

        public void WithUser(string username, string password)
        {
            _users.Add(new Tuple<string, string>(username, password));            
        }

        protected override void SetupFake()
        {            
            var initSetup = ServiceCall<ILoginProvider>.CreateServiceCall(FakeService);

            var setup = initSetup
                .AddMethodCall(MethodCall<ILoginProvider, string, string>
                    .CreateMethodCall(t => t.Login(It.IsAny<string>(), It.IsAny<string>()))                    
                    .BuildCallbacks(
                        (r,login, password) =>
                            _isLoginAttemptSuccessfulCollection.ContainsKey(login)
                                ? _isLoginAttemptSuccessfulCollection[login]
                                    ? r.Complete()
                                    : r.Throw(new Exception("unable to login"))
                                : r.Throw(new Exception("unable to login"))));

            setup.SetupService();
        }

        public void WithSuccessfulLogin(string username)
        {
            _isLoginAttemptSuccessfulCollection[username] = true;
        }
    }
}