using Attest.Testing.Contracts;

namespace Samples.Specifications.Tests.EndToEnd
{    
    internal sealed class ApplicationPathInfo : IApplicationPathInfo
    {
        public string Executable => "Samples.Specifications.Client.Launcher.exe";
        public string RelativePath => "..";
    }
}