namespace Samples.Specifications.Tests.Contracts.ScreenObjects
{
    public interface IExitScreenObject
    {
        bool IsDisplayed();
        void ExitWithSave();
        void ExitWithoutSave();
        void Cancel();
    }
}