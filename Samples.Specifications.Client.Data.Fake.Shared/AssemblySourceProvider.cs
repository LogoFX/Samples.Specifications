using Solid.Practices.Composition;

namespace Samples.Specifications.Client.Data.Fake.Shared
{    
    internal sealed class CustomAssemblySourceProvider : AssemblySourceProviderBase
    {
        private readonly string[] _endings;

        public CustomAssemblySourceProvider(string rootPath, string[] endings) : base(rootPath)
        {
            _endings = endings;
        }

        protected override string[] ResolveNamespaces() => _endings;
    }
}
