using Samples.Specifications.Tests.Steps.Helpers;

namespace Samples.Specifications.Tests.Steps
{
    public class GivenLoginSteps : IGivenLoginSteps
    {
        private readonly ISetupHelper _setupHelper;

        public GivenLoginSteps(ISetupHelper setupHelper)
        {
            _setupHelper = setupHelper;
        }

        public void SetupAuthenticatedUserWithCredentials(string username, string password)
        {                       
            _setupHelper.AddUser(username, password);            
        }
    }
}
