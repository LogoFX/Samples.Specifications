using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FlaUI.Core.AutomationElements;
using Samples.Specifications.Tests.Contracts.ScreenObjects;
using Samples.Specifications.Tests.Data;

namespace Samples.Specifications.Tests.EndToEnd.ScreenObjects
{
    class WarehouseScreenObject : IWarehouseScreenObject
    {
        public StructureHelper StructureHelper { get; set; }

        public WarehouseScreenObject(StructureHelper structureHelper)
        {
            StructureHelper = structureHelper;
        }

        public IEnumerable<WarehouseItemAssertionTestData> GetWarehouseItems()
        {
            var shell = StructureHelper.GetShell();
            var dataGrid = shell.FindFirstDescendant("WarehouseItemsDataGrid").AsGrid();
            return dataGrid.Rows.Select(CreateWarehouseItemAssertionTestData);
        }

        public WarehouseItemAssertionTestData GetWarehouseItemByKind(string kind)
        {
            var match = GetRowByKind(kind);
            return CreateWarehouseItemAssertionTestData(match);
        }

        private GridRow GetRowByKind(string kind)
        {
            var shell = StructureHelper.GetShell();
            var dataGrid = shell.FindFirstDescendant("WarehouseItemsDataGrid").AsGrid();
            var match = dataGrid.Rows.FirstOrDefault(t => t.Cells[0].Value == kind);
            if (match == null)
            {
                throw new InvalidOperationException($"Warehouse item {kind} cannot be found");
            }
            return match;
        }

        private void SelectRow(GridRow row)
        {
            row.Cells[0].Click();
        }

        private static WarehouseItemAssertionTestData CreateWarehouseItemAssertionTestData(GridRow t)
        {
            return new WarehouseItemAssertionTestData
            {
                Kind = t.Cells[0].Value,
                Price = double.Parse(t.Cells[1].Value),
                Quantity = int.Parse(t.Cells[2].Value),
                TotalCost = double.Parse(t.Cells[3].Value)
            };
        }

        public void EditWarehouseItem(string kind, string newKind, double? newPrice, int? newQuantity)
        {
            var match = GetRowByKind(kind);
            try
            {
                SelectRow(match);
            }
            catch (Exception err)
            {
                throw new InvalidOperationException($"Item {kind} cannot be found", err);
            }

            var shell = StructureHelper.GetShell();

            if (newKind != null)
            {
                var kindTextBox = shell.FindFirstDescendant("WarehouseItemKindTextBox").AsTextBox();
                kindTextBox.Enter(newKind);
            }

            if (newPrice != null)
            {
                var priceTextBox = shell.FindFirstDescendant("WarehouseItemPriceTextBox").AsTextBox();
                priceTextBox.Enter(newPrice.ToString());
            }

            if (newQuantity != null)
            {
                var quantityTextBox = shell.FindFirstDescendant("WarehouseItemQuantityTextBox").AsTextBox();
                quantityTextBox.Enter(newQuantity.ToString());
            }
        }

        public bool IsActive()
        {
            return true;
        }

        public void DeleteWarehouseItem(string kind)
        {
            var match = GetRowByKind(kind);
            try
            {
                match.Cells[0].Click();
            }
            catch (Exception err)
            {
                throw new InvalidOperationException($"Item {kind} cannot be found", err);
            }

            var shell = StructureHelper.GetShell();
            var deleteButton = shell.FindFirstDescendant("WarehouseItemDeleteButton").AsButton();
            deleteButton.Click();
        }

        public void AddWarehouseItem(WarehouseItemAssertionTestData warehouseItemData)
        {
            var shell = StructureHelper.GetShell();

            var kindTextBox = shell.FindFirstDescendant("WarehouseItemKindTextBox").AsTextBox();
            var priceTextBox = shell.FindFirstDescendant("WarehouseItemPriceTextBox").AsTextBox();
            var quantityTextBox = shell.FindFirstDescendant("WarehouseItemQuantityTextBox").AsTextBox();

            kindTextBox.Enter(warehouseItemData.Kind);
            priceTextBox.Text = warehouseItemData.Price.ToString(CultureInfo.CurrentCulture);
            quantityTextBox.Text = warehouseItemData.Quantity.ToString(CultureInfo.CurrentCulture);

            var applyButton = shell.FindFirstDescendant("WarehouseItemApplyButton").AsButton();
            applyButton.Click();
        }

        public string GetErrorMessage()
        {
            var shell = StructureHelper.GetShell();

            var errorTextBlock = shell.FindFirstDescendant("WarehouseItemErrorTextBlock").AsLabel();
            return errorTextBlock.Text;
        }

        public void DiscardChanges()
        {
            var shell = StructureHelper.GetShell();
            var discardControl = shell.FindFirstDescendant("DiscardChanges").AsButton();
            discardControl.Click();
        }

        public ControlStatusAssertionData AreStatusIndicatorsEnabled()
        {
            var shell = StructureHelper.GetShell();

            //The apply and discard changes controls don't refresh their state
            //unless the containing control is clicked
            //or app is minimized and then restored
            //The following two lines make sure the containing control is clicked
            var warehouseItemsContainer = shell.FindFirstDescendant("WarehouseItemsContainer");
            warehouseItemsContainer.Click();
            var applyControl = shell.FindFirstDescendant("WarehouseItemApplyButton").AsButton();
            var isApplyEnabled = applyControl.Properties.IsEnabled;
            var discardControl = shell.FindFirstDescendant("DiscardChanges").AsButton();
            var isDiscardEnabled = discardControl.Properties.IsEnabled;
            return new ControlStatusAssertionData
            {
                IsApplyEnabled = isApplyEnabled,
                IsDiscardEnabled = isDiscardEnabled
            };
        }
    }
}