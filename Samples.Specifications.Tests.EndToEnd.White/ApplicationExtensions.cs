using Samples.Specifications.Tests.Infra;
using System;
using System.Linq;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace Samples.Specifications.Tests.EndToEnd
{
    public static class ApplicationExtensions
    {
        public static Window GetWindowByTitle(this Application app, string title)
        {
            if (app.HasExited)
            {
                return null;
            }
            app.WaitWhileBusy();
            Func<Window> getWindow = () =>
            {
                var window = app.GetWindows().SingleOrDefault(x => x.Title == title);
                if (window == null || window.Visible == false || window.Enabled == false)
                {
                    throw new Exception();
                }
                return window;
            };
            return getWindow.ExecuteWithResult(5, TimeSpan.FromMilliseconds(500));            
        }
    }
}