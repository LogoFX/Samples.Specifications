namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    internal interface IExecutableContainer
    {
        string Path { get; }
    }

    class ExecutableContainer : IExecutableContainer
    {
        public string Path => "Samples.Specifications.Client.Launcher.exe";
    }
}