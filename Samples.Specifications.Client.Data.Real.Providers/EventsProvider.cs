using System;
using System.Collections.Generic;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Data.Contracts.Providers;

namespace Samples.Specifications.Client.Data.Real.Providers
{
    internal sealed class EventsProvider : IEventsProvider
    {
        IEnumerable<EventDto> IEventsProvider.GetLastEvents(DateTime lastEventTime) => new EventDto[] { };
    }
}