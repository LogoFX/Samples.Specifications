namespace Samples.Specifications.Tests.Acceptance.Contracts.ScreenObjects
{
    public interface ILoginScreenObject
    {
        void Login();
        void SetUsername(string username);
        void SetPassword(string password);
    }
}
