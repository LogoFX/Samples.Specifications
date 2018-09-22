using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd.White;

namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    internal class TeardownService : ITeardownService
    {
        public void Teardown()
        {
            ApplicationContext.Application?.Dispose();
        }
    }
}