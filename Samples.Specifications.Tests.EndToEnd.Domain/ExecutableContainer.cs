namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    internal interface IExecutableContainer
    {
        string Path { get; }
    }

    internal sealed class ExecutableContainer : IExecutableContainer
    {
        public string Path => "Samples.Specifications.Client.Launcher.exe";
    }
}