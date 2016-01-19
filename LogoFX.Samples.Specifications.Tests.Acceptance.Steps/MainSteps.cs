using System.Collections.Generic;
using Attest.Tests.Core;
using LogoFX.Samples.Specifications.Tests.Acceptance.ScreenObjects.Contracts;
using LogoFX.Samples.Specifications.Tests.Acceptance.TestData;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps
{
    public static class MainSteps
    {
        private static readonly IMainScreenObject _mainScreenObject = ScenarioHelper.Get<IMainScreenObject>();

        public static void ThenIExpectToSeeTheFollowingDataOnTheScreen(IEnumerable<WarehouseItemAssertionTestData> warehouseItems)
        {
            var actualWarehouseItems = _mainScreenObject.GetWarehouseItems();
        }
    }
}
