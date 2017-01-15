using LogoFX.Client.Testing.EndToEnd.White;
using Samples.Specifications.Tests.Domain.ScreenObjects;

namespace Samples.Specifications.Tests.EndToEnd.Domain.ScreenObjects
{
    class ExitScreenObject : IExitScreenObject
    {
        public bool IsDisplayed()
        {
            var application = ApplicationContext.Application;
            var exitWindow = application?.GetWindowEx("Exit options");
            return exitWindow?.Visible ?? false;
        }
    }
}