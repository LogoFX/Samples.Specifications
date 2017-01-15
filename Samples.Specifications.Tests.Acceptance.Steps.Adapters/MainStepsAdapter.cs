using System.Linq;
using Samples.Specifications.Tests.Data;
using Samples.Specifications.Tests.Steps;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Samples.Specifications.Tests.Acceptance.Steps.Adapters
{
    [Binding]
    class MainStepsAdapter
    {
        public MainSteps MainSteps { get; set; }

        public MainStepsAdapter(
            MainSteps mainSteps)
        {
            MainSteps = mainSteps;
        }

        [When(@"I set the Price for ""(.*)"" item to (.*)")]
        public void WhenISetThePriceForItemTo(string kind, int newPrice)
        {
            MainSteps.WhenISetThePriceForItemTo(kind, newPrice);
        }

        [When(@"I set the Quantity for ""(.*)"" item to (.*)")]
        public void WhenISetTheQuantityForItemTo(string kind, int newQuantity)
        {
            MainSteps.WhenISetTheQuantityForItemTo(kind, newQuantity);
        }

        [When(@"I set the Kind for ""(.*)"" item to ""(.*)""")]
        public void WhenISetTheKindForItemTo(string kind, string newKind)
        {
            MainSteps.WhenISetTheKindForItemTo(kind, newKind);
        }

        [When(@"I discard the changes")]
        public void WhenIDiscardTheChanges()
        {
            MainSteps.WhenIDiscardTheChanges();
        }

        [Then(@"I expect to see the following data on the screen:")]
        public void ThenIExpectToSeeTheFollowingDataOnTheScreen(Table table)
        {
            var warehouseItems = table.CreateSet<WarehouseItemAssertionTestData>();
            MainSteps.ThenIExpectToSeeTheFollowingDataOnTheScreen(warehouseItems.ToArray());
        }

        [Then(@"Total cost of ""(.*)"" item is (.*)")]
        public void ThenTotalCostOfItemIs(string kind, int expectedTotalCost)
        {
            MainSteps.ThenTotalCostOfItemIs(kind, expectedTotalCost);
        }

        [When(@"I delete ""(.*)"" item")]
        public void WhenIDeleteItem(string kind)
        {
            MainSteps.WhenIDeleteItem(kind);
        }

        [When(@"I create a new warehouse item with the following data:")]
        public void WhenICreateANewWarehouseItemWithTheFollowingData(Table table)
        {
            var warehouseItems = table.CreateSet<WarehouseItemAssertionTestData>();
            MainSteps.WhenICreateANewWarehouseItemWithTheFollowingData(warehouseItems.ToArray());
        }

        [Then(@"Error message is displayed with the following text ""(.*)""")]
        public void ThenErrorMessageIsDisplayedWithTheFollowingText(string expectedErrorMessage)
        {
            MainSteps.ThenErrorMessageIsDisplayedWithTheFollowingText(expectedErrorMessage);
        }        
    }
}
