using System;
using Attest.Fake.Builders;

namespace LogoFX.Samples.Specifications.Client.Data.Fake.ProviderBuilders
{
    [Serializable]
    public abstract class BuilderBase<TProvider> : FakeBuilderBase<TProvider> where TProvider : class
    {
        protected BuilderBase() : base(FakeFactoryFactory.CreateFakeFactory())
        {
        }
    }
}
