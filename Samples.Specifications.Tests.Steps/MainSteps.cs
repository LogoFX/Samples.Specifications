using FluentAssertions;
using Samples.Specifications.Tests.Domain.ScreenObjects;

namespace Samples.Specifications.Tests.Steps
{
    public class MainSteps
    {
        private readonly IMainScreenObject _mainScreenObject;

        public MainSteps(IMainScreenObject mainScreenObject)
        {
            _mainScreenObject = mainScreenObject;
        }

        public void ThenApplicationNavigatesToTheMainScreen()
        {
            var isActive = _mainScreenObject.IsActive();
            isActive.Should().BeTrue();
        }
    }
}
