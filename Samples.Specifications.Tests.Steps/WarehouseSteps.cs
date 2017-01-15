#if FAKE
using System.Linq;
using FluentAssertions;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;
#endif

namespace Samples.Specifications.Tests.Steps
{
    public class WarehouseSteps
    {
        private readonly WarehouseProviderBuilder _warehouseProviderBuilder;

        public WarehouseSteps(WarehouseProviderBuilder warehouseProviderBuilder)
        {
            _warehouseProviderBuilder = warehouseProviderBuilder;
        }

        public async void ThenTheStoredPriceForItemIs(string kind, int price)
        {
#if FAKE
            var items = await _warehouseProviderBuilder.GetService().GetWarehouseItems();
            var item = items.Single(t => t.Kind == kind);
            item.Price.Should().Be(price);
#endif
        }
    }
}