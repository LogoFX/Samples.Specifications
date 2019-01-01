using Attest.Testing.Contracts;
using JetBrains.Annotations;
using LogoFX.Client.Testing.Shared.Caliburn.Micro;
using Samples.Client.Model.Shared;

namespace Samples.Specifications.Client.Tests.Integration
{
    [UsedImplicitly]
    internal sealed class TeardownService : ITeardownService
    {
        public void Teardown()
        {
            UserContext.Current = null;
            TestHelper.Teardown();
        }
    }
}
