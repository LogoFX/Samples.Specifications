using LogoFX.Client.Testing.Contracts;

namespace Samples.Specifications.Tests.EndToEnd
{
    class TeardownService : ITeardownService
    {
        public void Teardown()
        {
            ApplicationContext.Application?.Close();
            ApplicationContext.Application?.Dispose();
        }
    }
}
