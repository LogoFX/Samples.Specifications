using System.Linq;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace Samples.Specifications.Tests.EndToEnd
{
    internal sealed class StructureHelper
    {
        internal Window GetShell()
        {
            var application = ApplicationContext.Application;
            application.WaitWhileBusy();
            using (var automation = new UIA3Automation())
            {
                var shellScreen =
                    DelegateExtensions.ExecuteWithResult(
                        () => application.GetAllTopLevelWindows(automation)
                            .FirstOrDefault(t => t.Properties.AutomationId == "Shell_Window"));
                return shellScreen;
            }
        }
    }
}