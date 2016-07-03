using System.Linq;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.ScreenObjects.EndToEnd
{
    public static class ApplicationExtensions
    {
        public static Window GetWindowEx(this Application app, string title)
        {
            return app.GetWindows().SingleOrDefault(x => x.Title == title);
        }
    }
}