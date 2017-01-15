using FluentAssertions;
using Samples.Specifications.Tests.Domain.ScreenObjects;

namespace Samples.Specifications.Tests.Steps
{
    public class ExitSteps
    {
        private readonly IExitScreenObject _exitScreenObject;

        public ExitSteps(IExitScreenObject exitScreenObject)
        {
            _exitScreenObject = exitScreenObject;
        }

        public void ThenTheExitApplicationOptionsDisplayStatusIs(bool status)
        {
            var isDisplayed = _exitScreenObject.IsDisplayed();
            isDisplayed.Should().Be(status);
        }
    }
}