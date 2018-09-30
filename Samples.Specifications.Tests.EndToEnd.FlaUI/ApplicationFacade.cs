using FlaUI.Core;
using LogoFX.Client.Testing.Contracts;

namespace Samples.Specifications.Tests.EndToEnd
{
    public class ApplicationFacade : IApplicationFacade
    {
        /// <summary>Starts the application.</summary>
        /// <param name="startupPath">The startup path.</param>
        public void Start(string startupPath)
        {
            ApplicationContext.Application = Application.Launch(startupPath);
            ApplicationContext.Application.WaitWhileBusy();
        }

        public void Stop()
        {
            var application = ApplicationContext.Application;
            application?.Dispose();
        }
    }
}