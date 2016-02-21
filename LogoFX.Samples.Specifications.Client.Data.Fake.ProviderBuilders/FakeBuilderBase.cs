using System;
using Attest.Fake.Setup;
using Attest.Fake.Setup.Contracts;

namespace LogoFX.Samples.Specifications.Client.Data.Fake.ProviderBuilders
{
    [Serializable]
    public abstract class FakeBuilderBase<TProvider> : Attest.Fake.Builders.FakeBuilderBase<TProvider> where TProvider : class
    {
        protected FakeBuilderBase() : base(FakeFactoryFactory.CreateFakeFactory())
        {
        }

        protected IHaveNoMethods<TProvider> CreateInitialSetup()
        {
            return ServiceCallFactory.CreateServiceCall(FakeService);
        }
    }
}
