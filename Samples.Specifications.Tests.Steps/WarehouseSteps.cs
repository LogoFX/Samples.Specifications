using FluentAssertions;
using Samples.Specifications.Tests.Domain.ScreenObjects;

namespace Samples.Specifications.Tests.Steps
{
    public class WarehouseSteps
    {
        private readonly IMainScreenObject _mainScreenObject;

        public WarehouseSteps(IMainScreenObject mainScreenObject)
        {
            _mainScreenObject = mainScreenObject;
        }

        public void ThenTheChangesAreSaved()
        {
            var statuses = _mainScreenObject.AreStatusIndicatorsEnabled();
            statuses.Item1.Should().BeFalse();
            statuses.Item1.Should().BeFalse();
        }

        public void ThenThePriceForItemIs(string kind, int price)
        {
            var row = _mainScreenObject.GetWarehouseItemByKind(kind);
            row.Price.Should().Be(price);
        }
    }
}