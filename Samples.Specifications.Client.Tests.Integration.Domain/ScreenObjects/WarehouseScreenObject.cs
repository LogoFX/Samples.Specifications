using System.Collections.Generic;
using System.Linq;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;
using Samples.Specifications.Client.Tests.Integration.Infra.Core;
using Samples.Specifications.Tests.Data;
using Samples.Specifications.Tests.Domain.ScreenObjects;

namespace Samples.Specifications.Client.Tests.Integration.Domain.ScreenObjects
{
    class WarehouseScreenObject : IWarehouseScreenObject
    {
        public StructureHelper StructureHelper { get; }

        public WarehouseScreenObject(StructureHelper structureHelper)
        {
            StructureHelper = structureHelper;
        }       

        public void AddWarehouseItem(WarehouseItemAssertionTestData warehouseItemData)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteWarehouseItem(string kind)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<WarehouseItemAssertionTestData> GetWarehouseItems()
        {
            var main = StructureHelper.GetMain();
            return main.WarehouseItems.Items.OfType<WarehouseItemViewModel>()
                .Select(t => new WarehouseItemAssertionTestData
                {
                    Kind = t.Model.Kind,
                    Price = t.Model.Price,
                    Quantity = t.Model.Quantity,
                    TotalCost = t.Model.TotalCost
                });
        }

        public WarehouseItemAssertionTestData GetWarehouseItemByKind(string kind)
        {
            var main = StructureHelper.GetMain();
            return
                main.WarehouseItems.Items.OfType<WarehouseItemViewModel>()
                    .Where(t => t.Model.Kind == kind)
                    .Select(t => new WarehouseItemAssertionTestData
                    {
                        Kind = t.Model.Kind,
                        Price = t.Model.Price,
                        Quantity = t.Model.Quantity,
                        TotalCost = t.Model.TotalCost
                    }).Single();
        }

        private int _temporaryHashCode;

        public void EditWarehouseItem(string kind, string newKind, double? newPrice, int? newQuantity)
        {
            var main = StructureHelper.GetMain();
            var itemViewModel =
                main.WarehouseItems.Items
                    .OfType<WarehouseItemViewModel>().Single(t => t.Model.Kind == kind);

            _temporaryHashCode = itemViewModel.GetHashCode();
            if (newKind != null)
            {
                itemViewModel.Model.Kind = newKind;
            }
            
            if (newPrice != null)
            {
                itemViewModel.Model.Price = newPrice.Value;
            }

            if (newQuantity != null)
            {
                itemViewModel.Model.Quantity = newQuantity.Value;
            }
        }

        public string GetErrorMessage()
        {
            var main = StructureHelper.GetMain();
            var match = main.WarehouseItems.Items.OfType<WarehouseItemViewModel>()
                .Single(t => t.GetHashCode() == _temporaryHashCode);
            return match.Model.Error;
        }

        public void DiscardChanges()
        {
            throw new System.NotImplementedException();
        }

        public ControlStatusAssertionData AreStatusIndicatorsEnabled()
        {
            throw new System.NotImplementedException();
        }
    }

    class MainScreenObject : IMainScreenObject
    {
        public StructureHelper StructureHelper { get; set; }

        public MainScreenObject(StructureHelper structureHelper)
        {
            StructureHelper = structureHelper;
        }

        public bool IsActive()
        {
            var main = StructureHelper.GetMain();
            return main.IsActive;
        }
    }
}