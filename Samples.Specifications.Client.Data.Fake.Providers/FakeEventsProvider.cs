using System;
using System.Collections.Generic;
using Attest.Fake.Builders;
using JetBrains.Annotations;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Data.Contracts.Providers;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;

namespace Samples.Specifications.Client.Data.Fake.Providers
{
    [UsedImplicitly]
    class FakeEventsProvider : FakeProviderBase<EventsProviderBuilder, IEventsProvider>, IEventsProvider
    {
        private readonly EventsProviderBuilder _eventsProviderBuilder;

        public FakeEventsProvider(EventsProviderBuilder eventsProviderBuilder)
        {
            _eventsProviderBuilder = eventsProviderBuilder;
        }

        IEnumerable<EventDto> IEventsProvider.GetLastEvents(DateTime lastEventTime)
        {
            var service = GetService(() => _eventsProviderBuilder, b => b);
            return service.GetLastEvents(lastEventTime);
        }
    }
}