using LogoFX.Client.Testing.Contracts;
using Samples.Specifications.Client.Tests.Integration.Infra.Shared;

namespace Samples.Specifications.Client.Tests.Integration.Domain
{
    internal sealed class TeardownService : ITeardownService
    {
        public void Teardown()
        {
            TestHelper.AfterTeardown();
        }
    }
}
