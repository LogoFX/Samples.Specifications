using Attest.Fake.Builders;
using Attest.Fake.Moq;
using JetBrains.Annotations;
using Solid.Practices.Modularity;

namespace LogoFX.Samples.Specifications.Client.Data.Fake.ProviderBuilders
{    
    [UsedImplicitly]    
    class Module : IPlainCompositionModule
    {
        public void RegisterModule()
        {
            FakeFactoryContext.Current = new FakeFactory();
        }
    }
}
