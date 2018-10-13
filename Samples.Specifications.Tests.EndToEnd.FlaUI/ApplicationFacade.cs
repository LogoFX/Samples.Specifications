using Attest.Testing.Contracts;
using FlaUI.Core;

namespace Samples.Specifications.Tests.EndToEnd
{
    internal sealed class ApplicationFacade : IApplicationFacade
    {           
        public void Start(string startupPath)
        {
            ApplicationContext.Application = Application.Launch(startupPath);
            ApplicationContext.Application.WaitWhileBusy();
        }

        public void Stop()
        {            
            ApplicationContext.Application?.Close();
            ApplicationContext.Application?.Dispose();
        }
    }
}