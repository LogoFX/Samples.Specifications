using LogoFX.Client.Tests.EndToEnd.White;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.ScreenObjects.EndToEnd
{
    static class StructureHelper
    {
        internal static Window GetShell()
        {
            var application = ApplicationContext.Application;
            var shellScreen =
                application.GetWindow(SearchCriteria.ByAutomationId("Shell_Window"), InitializeOption.NoCache);
            return shellScreen;
        }
    }
}