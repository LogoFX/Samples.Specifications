namespace Samples.Specifications.Tests.EndToEnd
{
    internal interface IApplicationPathWrapper
    {
        string Executable { get; }
        string RelativePath { get; }
    }

    internal sealed class ApplicationPathWrapper : IApplicationPathWrapper
    {
        public string Executable => "Samples.Specifications.Client.Launcher.exe";
        public string RelativePath => "..";
    }
}