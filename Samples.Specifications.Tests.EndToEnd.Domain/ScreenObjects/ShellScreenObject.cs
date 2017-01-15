using LogoFX.Client.Testing.EndToEnd.White;
using Samples.Specifications.Tests.Domain.ScreenObjects;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;

namespace Samples.Specifications.Tests.EndToEnd.Domain.ScreenObjects
{
    class ShellScreenObject : IShellScreenObject
    {
        public void Close()
        {
            var application = ApplicationContext.Application;
            var shell = application.GetWindow(SearchCriteria.ByAutomationId("Shell_Window"),InitializeOption.NoCache);
            shell.Close();
        }
    }
}
