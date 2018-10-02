using Solid.Practices.Composition;

namespace Samples.Specifications.Client.Data.Fake.Shared
{
    internal sealed class BuildersAssemblySourceProvider : AssemblySourceProviderBase
    {
        internal BuildersAssemblySourceProvider(string rootPath) : base(rootPath)
        {
        }

        protected override string[] ResolveNamespaces()
        {
            return new[] { Consts.BuildersAssemblyEnding };
        }
    }

    internal sealed class ProvidersAssemblySourceProvider : AssemblySourceProviderBase
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
