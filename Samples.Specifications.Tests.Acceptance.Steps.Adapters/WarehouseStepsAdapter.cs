using Samples.Specifications.Tests.Steps;
using TechTalk.SpecFlow;

namespace Samples.Specifications.Tests.Acceptance.Steps.Adapters
{
    [Binding]
    class WarehouseStepsAdapter
    {
        public WarehouseSteps WarehouseSteps { get; set; }

        public WarehouseStepsAdapter(WarehouseSteps warehouseSteps)
        {
            WarehouseSteps = warehouseSteps;
        }

        [Then(@"the stored Price for ""(.*)"" item is (.*)")]
        public void ThenTheStoredPriceForItemIs(string kind, int price)
        {
            WarehouseSteps.ThenTheStoredPriceForItemIs(kind, price);
        }

        [Then(@"the changes are saved")]
        public void ThenTheChangesAreSaved()
        {
            WarehouseSteps.ThenTheChangesAreSaved();
        }
    }
}