using Attest.Testing.Contracts;
using Samples.Client.Model.Shared;

namespace Samples.Specifications.Client.Tests.Integration
{
    internal sealed class TeardownService : ITeardownService
    {
        public void Teardown()
        {
            UserContext.Current = null;
            LogoFX.Client.Testing.Shared.Caliburn.Micro.TestHelper.Teardown();
        }
    }
}
