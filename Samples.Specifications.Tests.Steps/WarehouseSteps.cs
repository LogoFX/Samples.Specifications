﻿using System;
using System.Linq;
using FluentAssertions;
using Samples.Specifications.Tests.Data;
using Samples.Specifications.Tests.Domain.ScreenObjects;

namespace Samples.Specifications.Tests.Steps
{
    public class WarehouseSteps
    {
        private readonly IWarehouseScreenObject _warehouseScreenObject;

        public WarehouseSteps(IWarehouseScreenObject warehouseScreenObject)
        {
            _warehouseScreenObject = warehouseScreenObject;
        }

        public void WhenISetThePriceForItemTo(string kind, int newPrice)
        {
            _warehouseScreenObject.EditWarehouseItem(kind, newPrice: newPrice);
        }

        public void WhenISetTheQuantityForItemTo(string kind, int newQuantity)
        {
            _warehouseScreenObject.EditWarehouseItem(kind, newQuantity: newQuantity);
        }

        public void WhenISetTheKindForItemTo(string kind, string newKind)
        {
            _warehouseScreenObject.EditWarehouseItem(kind, newKind: newKind);
        }

        public void ThenIExpectToSeeTheFollowingDataOnTheScreen(WarehouseItemAssertionTestData[] warehouseItems)
        {            
            var actualWarehouseItems = _warehouseScreenObject.GetWarehouseItems().ToArray();
            for (int i = 0; i < Math.Max(warehouseItems.Length, actualWarehouseItems.Length); i++)
            {
                var expectedWarehouseItem = warehouseItems[i];
                var actualWarehouseItem = actualWarehouseItems[i];
                actualWarehouseItem.Kind.Should().Be(expectedWarehouseItem.Kind);
                actualWarehouseItem.Price.Should().Be(expectedWarehouseItem.Price);
                actualWarehouseItem.Quantity.Should().Be(expectedWarehouseItem.Quantity);
                actualWarehouseItem.TotalCost.Should().Be(expectedWarehouseItem.TotalCost);
            }
        }

        public void ThenTotalCostOfItemIs(string kind, int expectedTotalCost)
        {
            var actualWarehouseItem = _warehouseScreenObject.GetWarehouseItemByKind(kind);
            actualWarehouseItem.TotalCost.Should().Be(expectedTotalCost);
        }        

        public void WhenIDeleteItem(string kind)
        {
            _warehouseScreenObject.DeleteWarehouseItem(kind);
        }

        public void WhenICreateANewWarehouseItemWithTheFollowingData(WarehouseItemAssertionTestData[] warehouseItems)
        {            
            foreach (var warehouseItem in warehouseItems)
            {
                _warehouseScreenObject.AddWarehouseItem(warehouseItem);
            }
        }

        public void ThenErrorMessageIsDisplayedWithTheFollowingText(string expectedErrorMessage)
        {
            var actualErrorMessage = _warehouseScreenObject.GetErrorMessage();
            actualErrorMessage.Should().Be(expectedErrorMessage);
        }

        public void WhenIDiscardTheChanges()
        {
            _warehouseScreenObject.DiscardChanges();
        }

        public void ThenTheChangesAreSaved()
        {
            ThenTheChangesControlsStatusIs(false);
        }

        public void ThenTheChangesAreDiscarded()
        {
            ThenTheChangesControlsStatusIs(false);
        }

        public void ThenTheChangesAreIntact()
        {
            ThenTheChangesControlsStatusIs(true);
        }

        public void ThenThePriceForItemIs(string kind, double price)
        {
            var row = _warehouseScreenObject.GetWarehouseItemByKind(kind);
            row.Price.Should().Be(price);
        }

        public void ThenTheQuantityForItemIs(string kind, int quantity)
        {
            var row = _warehouseScreenObject.GetWarehouseItemByKind(kind);
            row.Quantity.Should().Be(quantity);
        }                

        private void ThenTheChangesControlsStatusIs(bool status)
        {
            var statuses = _warehouseScreenObject.AreStatusIndicatorsEnabled();
            statuses.IsApplyEnabled.Should().Be(status);
            statuses.IsDiscardEnabled.Should().Be(status);
        }
    }
}