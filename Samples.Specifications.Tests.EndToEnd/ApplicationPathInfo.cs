using System.IO;
using Attest.Testing.Contracts;
using JetBrains.Annotations;

namespace Samples.Specifications.Tests.EndToEnd
{    
    [UsedImplicitly]
    internal sealed class ApplicationPathInfo : IApplicationPathInfo
    {
        public string Executable => "Samples.Specifications.Client.Launcher.exe";
        public string RelativePath => Path.Combine("..", "..",
#if FAKE
    "EndToEndWithFake"
#elif REAL
    "EndToEndWithReal"
#endif
        );
    }
}