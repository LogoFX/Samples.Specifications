using System.IO;
using Attest.Testing.Contracts;
using JetBrains.Annotations;

namespace Samples.Specifications.Tests.Modules.Server
{
    [UsedImplicitly]
    internal sealed class ApplicationPathInfo : IApplicationPathInfo
    {
        public string Executable => "Samples.Specifications.Server.Facade.dll";
        public string RelativePath => Path.Combine("..", "..", "server","Debug");
    }
}
