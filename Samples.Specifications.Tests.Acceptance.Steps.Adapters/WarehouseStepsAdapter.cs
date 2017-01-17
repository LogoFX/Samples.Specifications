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

        [Then(@"the Price for ""(.*)"" item is (.*)")]
        public void ThenThePriceForItemIs(string kind, int price)
        {
            WarehouseSteps.ThenThePriceForItemIs(kind, price);
        }

        [Then(@"the changes are saved")]
        public void ThenTheChangesAreSaved()
        {
            WarehouseSteps.ThenTheChangesAreSaved();
        }
    }
}