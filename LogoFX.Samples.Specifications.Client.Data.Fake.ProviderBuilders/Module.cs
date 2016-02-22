using System.Composition;
using Attest.Fake.Builders;
using Attest.Fake.Moq;
using LogoFX.Client.Bootstrapping.Adapters.Unity;
using Solid.Practices.Modularity;

namespace LogoFX.Samples.Specifications.Client.Data.Fake.ProviderBuilders
{
    [Export(typeof(ICompositionModule))]
    class Module : ICompositionModule<UnityContainerAdapter>
    {
        public void RegisterModule(UnityContainerAdapter iocContainer)
        {
            FakeFactoryContext.Current = new FakeFactory();
        }
    }
}
