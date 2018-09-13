namespace Samples.Specifications.Tests.Steps
{
    public interface IGivenLoginSteps
    {
        void SetupAuthenticatedUserWithCredentials(string username, string password);
    }
}
