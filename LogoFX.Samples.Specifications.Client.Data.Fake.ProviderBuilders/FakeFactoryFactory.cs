using Attest.Fake.Core;
using Attest.Fake.Moq;

namespace LogoFX.Samples.Specifications.Client.Data.Fake.ProviderBuilders
{
    static class FakeFactoryFactory
    {
        private static readonly IFakeFactory _fakeFactory = new FakeFactory();

        internal static IFakeFactory CreateFakeFactory()
        {
            return _fakeFactory;
        }
    }
}