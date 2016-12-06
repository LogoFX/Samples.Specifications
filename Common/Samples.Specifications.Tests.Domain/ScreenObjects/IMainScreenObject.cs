using System.Collections.Generic;
using Samples.Specifications.Tests.Data;

namespace Samples.Specifications.Tests.Domain.ScreenObjects
{
    public interface IMainScreenObject
    {
        IEnumerable<WarehouseItemAssertionTestData> GetWarehouseItems();
        WarehouseItemAssertionTestData GetWarehouseItemByKind(string kind);
        void EditWarehouseItem(string kind, string fieldName, string fieldValue);
        bool IsActive();
    }
}