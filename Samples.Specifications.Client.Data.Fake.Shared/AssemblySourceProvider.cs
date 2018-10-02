using Solid.Practices.Composition;

namespace Samples.Specifications.Client.Data.Fake.Shared
{
    public class BuildersAssemblySourceProvider : AssemblySourceProviderBase
    {
        public BuildersAssemblySourceProvider(string rootPath) : base(rootPath)
        {
        }

        protected override string[] ResolveNamespaces()
        {
            return new[] { Consts.BuildersAssemblyEnding };
        }
    }

    public class ProvidersAssemblySourceProvider : AssemblySourceProviderBase
    {
        public ProvidersAssemblySourceProvider(string rootPath) : base(rootPath)
        {
        }

        protected override string[] ResolveNamespaces()
        {
            return new[] { Consts.ContractsAssemblyEnding, Consts.FakeAssemblyEnding, Consts.BuildersAssemblyEnding };
        }
    }
}
