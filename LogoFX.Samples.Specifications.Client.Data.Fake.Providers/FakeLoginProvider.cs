using Attest.Fake.Builders;
using JetBrains.Annotations;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Providers;
using LogoFX.Samples.Specifications.Client.Data.Fake.Containers;
using LogoFX.Samples.Specifications.Client.Data.Fake.ProviderBuilders;

namespace LogoFX.Samples.Specifications.Client.Data.Fake.Providers
{
    [UsedImplicitly]
    class FakeLoginProvider : FakeProviderBase<LoginProviderBuilder, ILoginProvider>, ILoginProvider
    {
        private readonly LoginProviderBuilder _loginProviderBuilder;

        public FakeLoginProvider(
            LoginProviderBuilder loginProviderBuilder,
            IUserContainer userContainer)
        {
            _loginProviderBuilder = loginProviderBuilder;
            foreach (var user in userContainer.Users)
            {
                _loginProviderBuilder.WithUser(user.Item1, user.Item2);
                _loginProviderBuilder.WithSuccessfulLogin(user.Item1);
            }            
        }

        void ILoginProvider.Login(string username, string password)
        {
            var service = GetService(() => _loginProviderBuilder, b => b);
            service.Login(username, password);
        }
    }
}