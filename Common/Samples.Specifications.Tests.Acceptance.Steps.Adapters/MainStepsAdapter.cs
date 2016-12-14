﻿using System.Linq;
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

        public MainStepsAdapter(MainSteps mainSteps)
        {
            MainSteps = mainSteps;
        }

        [When(@"I set the Price for ""(.*)"" item to (.*)")]
        public void WhenISetThePriceForItemTo(string kind, int newPrice)
        {
            MainSteps.WhenISetThePriceForItemTo(kind, newPrice);
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

        [When(@"I add data:")]
        public void WhenIAddData(Table table)
        {
            var warehouseItems = table.CreateSet<WarehouseItemAssertionTestData>();
            MainSteps.WhenIAddData(warehouseItems.ToArray());
        }
    }
}
