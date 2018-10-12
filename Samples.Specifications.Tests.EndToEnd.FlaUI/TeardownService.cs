using Attest.Testing.Contracts;
using LogoFX.Client.Testing.Contracts;

namespace Samples.Specifications.Tests.EndToEnd
{
    internal sealed class TeardownService : ITeardownService
    {
        private readonly IApplicationFacade _applicationFacade;

        public TeardownService(IApplicationFacade applicationFacade)
        {
            _applicationFacade = applicationFacade;
        }

        public void Teardown()
        {
            _applicationFacade.Stop();
        }
    }
}
