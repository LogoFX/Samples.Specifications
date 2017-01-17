﻿#if FAKE
using System.Linq;
using FluentAssertions;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;
using Samples.Specifications.Tests.Domain.ScreenObjects;

#endif

namespace Samples.Specifications.Tests.Steps
{
    public class WarehouseSteps
    {
        private readonly WarehouseProviderBuilder _warehouseProviderBuilder;
        private readonly IMainScreenObject _mainScreenObject;

        public WarehouseSteps(
            WarehouseProviderBuilder warehouseProviderBuilder,
            IMainScreenObject mainScreenObject)
        {
            _warehouseProviderBuilder = warehouseProviderBuilder;
            _mainScreenObject = mainScreenObject;
        }

        public async void ThenTheStoredPriceForItemIs(string kind, int price)
        {
#if FAKE
            var items = await _warehouseProviderBuilder.GetService().GetWarehouseItems();
            var item = items.Single(t => t.Kind == kind);
            item.Price.Should().Be(price);
#endif
        }

        public void ThenTheChangesAreSaved()
        {
            var statuses = _mainScreenObject.AreStatusIndicatorsEnabled();
            statuses.Item1.Should().BeFalse();
            statuses.Item1.Should().BeFalse();
        }
    }
}