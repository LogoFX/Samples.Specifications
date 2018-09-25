namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    internal interface IApplicationPathWrapper
    {
        string Path { get; }
    }

    internal sealed class ApplicationPathWrapper : IApplicationPathWrapper
    {
        public string Path => "Samples.Specifications.Client.Launcher.exe";
    }
}