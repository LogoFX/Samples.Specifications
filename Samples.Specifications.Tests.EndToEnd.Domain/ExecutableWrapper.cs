namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    internal interface IExecutableWrapper
    {
        string Path { get; }
    }

    internal sealed class ExecutableWrapper : IExecutableWrapper
    {
        public string Path => "Samples.Specifications.Client.Launcher.exe";
    }
}