using Attest.Fake.Builders;
using JetBrains.Annotations;
using Samples.Client.Data.Contracts.Providers;
using Samples.Specifications.Client.Data.Fake.Containers;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;

namespace Samples.Specifications.Client.Data.Fake.Providers
{
    [UsedImplicitly]
    class FakeLoginProvider : FakeProviderBase<LoginProviderBuilder, ILoginProvider>, ILoginProvider
    {
        public FakeLoginProvider(
            LoginProviderBuilder loginProviderBuilder,
            IUserContainer userContainer)
            :base(loginProviderBuilder)
        {
            foreach (var user in userContainer.Users)
            {
                loginProviderBuilder.WithUser(user.Item1, user.Item2);
            }
        }

        void ILoginProvider.Login(string username, string password)
        {
            var service = GetService();
            service.Login(username, password);
        }
    }
}