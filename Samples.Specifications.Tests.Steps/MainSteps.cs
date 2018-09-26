using FluentAssertions;
using Samples.Specifications.Tests.Contracts.ScreenObjects;

namespace Samples.Specifications.Tests.Steps
{
    public sealed class MainSteps
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
