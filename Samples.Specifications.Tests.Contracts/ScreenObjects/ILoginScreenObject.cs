namespace Samples.Specifications.Tests.Contracts.ScreenObjects
{
    public interface ILoginScreenObject
    {
        void Login();
        void SetUsername(string username);
        void SetPassword(string password);
        string GetErrorMessage();
    }
}
