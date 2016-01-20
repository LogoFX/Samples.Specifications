using System;
using System.Linq;
using Attest.Tests.Core;
using LogoFX.Samples.Specifications.Tests.Acceptance.ScreenObjects.Contracts;
using LogoFX.Samples.Specifications.Tests.Acceptance.TestData;
using Shouldly;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps
{
    public static class MainSteps
    {
        private static readonly IMainScreenObject _mainScreenObject = ScenarioHelper.Get<IMainScreenObject>();

        public static void ThenIExpectToSeeTheFollowingDataOnTheScreen(WarehouseItemAssertionTestData[] warehouseItems)
        {
            var actualWarehouseItems = _mainScreenObject.GetWarehouseItems().ToArray();
            for (int i = 0; i < Math.Max(warehouseItems.Length, actualWarehouseItems.Length); i++)
            {
                var expectedWarehouseItem = warehouseItems[i];
                var actualWarehouseItem = actualWarehouseItems[i];
                actualWarehouseItem.Kind.ShouldBe(expectedWarehouseItem.Kind);
                actualWarehouseItem.Price.ShouldBe(expectedWarehouseItem.Price);
                actualWarehouseItem.Quantity.ShouldBe(expectedWarehouseItem.Quantity);
                actualWarehouseItem.TotalCost.ShouldBe(expectedWarehouseItem.TotalCost);               
            }            
        }
    }
}
