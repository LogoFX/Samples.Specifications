using LogoFX.Client.Testing.EndToEnd.White;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    class StructureHelper
    {
        internal Window GetShell()
        {
            var application = ApplicationContext.Application;
            var shellScreen =
                DelegateExtensions.ExecuteWithResult(
                    () => application.GetWindow(SearchCriteria.ByAutomationId("Shell_Window"), InitializeOption.NoCache)); 
            shellScreen.WaitWhileBusy();
            return shellScreen;
        }
    }
}