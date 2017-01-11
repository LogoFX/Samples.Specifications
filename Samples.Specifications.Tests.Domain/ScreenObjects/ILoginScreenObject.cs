namespace Samples.Specifications.Tests.Domain.ScreenObjects
{
    public interface ILoginScreenObject
    {
        void Login();
        void SetUsername(string username);
        void SetPassword(string password);
        string GetErrorMessage();
    }
}
