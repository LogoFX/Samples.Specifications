using TechTalk.SpecFlow;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps.Adapters
{
    [Binding]
    class GivenLoginStepsAdapter
    {
        [Given(@"I am able to log in successfully with username '(.*)' and password '(.*)'")]
        public void GivenIAmAbleToLogInSuccessfullyWithUsernameAndPassword(string userName, string password)
        {
            GivenLoginSteps.SetupAuthenticatedUserWithCredentials(userName, password);
            GivenLoginSteps.SetupLoginSuccessfullyWithUsername(userName);
        }

    }
}
