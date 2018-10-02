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
    internal sealed class FakeEventsProvider : FakeProviderBase<EventsProviderBuilder, IEventsProvider>, IEventsProvider
    {
        public FakeEventsProvider(EventsProviderBuilder eventsProviderBuilder)
            : base(eventsProviderBuilder)
        {
        }

        IEnumerable<EventDto> IEventsProvider.GetLastEvents(DateTime lastEventTime) =>
            GetService().GetLastEvents(lastEventTime);
    }
}