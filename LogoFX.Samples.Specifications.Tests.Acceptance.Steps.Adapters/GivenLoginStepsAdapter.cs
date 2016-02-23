﻿using TechTalk.SpecFlow;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps.Adapters
{
    [Binding]
    class GivenLoginStepsAdapter
    {
        [Given(@"I am able to log in successfully with username ""(.*)""")]
        public void GivenIAmAbleToLogInSuccessfullyWithUsername(string userName)
        {
            GivenLoginSteps.SetupAuthenticatedUserWithUsername(userName);
            GivenLoginSteps.SetupLoginSuccessfullyWithUsername(userName);
        }
    }
}