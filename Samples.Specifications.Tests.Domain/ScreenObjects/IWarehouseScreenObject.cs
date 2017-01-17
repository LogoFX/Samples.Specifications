using System;
using System.Collections.Generic;
using Samples.Specifications.Tests.Data;

namespace Samples.Specifications.Tests.Domain.ScreenObjects
{
    public interface IWarehouseScreenObject
    {
        IEnumerable<WarehouseItemAssertionTestData> GetWarehouseItems();
        WarehouseItemAssertionTestData GetWarehouseItemByKind(string kind);        
        void EditWarehouseItem(string kind, string newKind = null, double? newPrice = null, int? newQuantity = null);
        void AddWarehouseItem(WarehouseItemAssertionTestData warehouseItemData);
        void DeleteWarehouseItem(string kind);
        string GetErrorMessage();
        void DiscardChanges();
        Tuple<bool, bool> AreStatusIndicatorsEnabled();
    }
}