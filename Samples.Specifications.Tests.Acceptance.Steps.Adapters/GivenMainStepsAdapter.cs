using System;
using System.Linq;
using Samples.Client.Data.Contracts.Dto;
using Samples.Specifications.Tests.Steps;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Samples.Specifications.Tests.Acceptance.Steps.Adapters
{
    [Binding]
    class GivenMainStepsAdapter
    {
        public IGivenMainSteps GivenMainSteps { get; set; }

        public GivenMainStepsAdapter(IGivenMainSteps givenMainSteps)
        {
            GivenMainSteps = givenMainSteps;
        }

        [Given(@"warehouse contains the following items:")]
        public void GivenWarehouseContainsTheFollowingItems(Table table)
        {
            var warehouseItems = table.CreateSet<WarehouseItemDto>().ToArray();
            foreach (var warehouseItemDto in warehouseItems)
            {
                warehouseItemDto.Id = Guid.NewGuid();
            }
            GivenMainSteps.SetupWarehouseItems(warehouseItems);
        }
    }
}
