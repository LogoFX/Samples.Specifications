using System.Collections.Generic;
using System.Linq;
using LogoFX.Samples.Specifications.Tests.Acceptance.ScreenObjects.Contracts;
using LogoFX.Samples.Specifications.Tests.Acceptance.TestData;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.ScreenObjects.EndToEnd
{
    public class MainScreenObject : IMainScreenObject
    {
        public IEnumerable<WarehouseItemAssertionTestData> GetWarehouseItems()
        {
            var shell = StructureHelper.GetShell();
            var dataGrid = shell.Get<ListView>(SearchCriteria.ByAutomationId("WarehouseItemsDataGrid"));
            return dataGrid.Rows.Select(t =>
                new WarehouseItemAssertionTestData
                {
                    Kind = t.Cells["Kind"].Text,                    
                    Price = double.Parse(t.Cells["Price"].Text),
                    Quantity = int.Parse(t.Cells["Quantity"].Text),
                    TotalCost = double.Parse(t.Cells["Total cost"].Text)
                });            
        }
    }
}