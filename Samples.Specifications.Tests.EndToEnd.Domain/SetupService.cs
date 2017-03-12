using System.IO;
using LogoFX.Client.Testing.EndToEnd.White;
using Samples.Specifications.Tests.Domain;

namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    class SetupService : ISetupService
    {
        public void Setup()
        {
            File.Delete("objects.ndb");
        }
    }

    class TeardownService : ITeardownService
    {
        public void Teardown()
        {
            ApplicationContext.Application?.Dispose();
        }
    }
}
