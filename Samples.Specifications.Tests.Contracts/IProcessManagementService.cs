namespace Samples.Specifications.Tests.Contracts
{
    public interface IProcessManagementService
    {
        int Start(string tool, string args);
        void Stop(int processId);
    }
}
