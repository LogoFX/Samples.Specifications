using Attest.Testing.Contracts;
using Samples.Specifications.Client.Tests.Integration.Infra.Shared;

namespace Samples.Specifications.Client.Tests.Integration
{
    internal sealed class TeardownService : ITeardownService
    {
        public void Teardown()
        {
            TestHelper.AfterTeardown();
        }
    }
}
