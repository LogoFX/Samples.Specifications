using System.Collections.Generic;
using Samples.Specifications.Tests.Acceptance.TestData;

namespace Samples.Specifications.Tests.Acceptance.Contracts.ScreenObjects
{
    public interface IMainScreenObject
    {
        IEnumerable<WarehouseItemAssertionTestData> GetWarehouseItems();
        WarehouseItemAssertionTestData GetWarehouseItemByKind(string kind);
        void EditWarehouseItem(string kind, string fieldName, string fieldValue);
    }
}