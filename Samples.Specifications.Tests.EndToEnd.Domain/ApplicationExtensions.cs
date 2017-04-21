using System;
using System.Linq;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    public static class ApplicationExtensions
    {
        public static Window GetWindowEx(this Application app, string title)
        {
            if (app.HasExited)
            {
                return null;
            }
            app.WaitWhileBusy();
            var loginWindow = app.GetWindows().SingleOrDefault(x => x.Title == title);
            if (loginWindow?.Visible == false || loginWindow?.Enabled == false)
            {
                throw new Exception();
            }
            return loginWindow;
        }
    }
}