using System.Collections.Generic;
using LogoFX.Samples.Specifications.Tests.Acceptance.TestData;

namespace Samples.Specifications.Tests.Acceptance.Contracts
{
    public interface IMainScreenObject
    {
        IEnumerable<WarehouseItemAssertionTestData> GetWarehouseItems();
        WarehouseItemAssertionTestData GetWarehouseItemByKind(string kind);
        void EditWarehouseItem(string kind, string fieldName, string fieldValue);
    }
}