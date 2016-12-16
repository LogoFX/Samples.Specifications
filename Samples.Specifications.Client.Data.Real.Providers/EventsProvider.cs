using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Data.Contracts.Providers;

namespace Samples.Specifications.Client.Data.Real.Providers
{
    class EventsProvider : IEventsProvider
    {
        public Task<IEnumerable<EventDto>> GetLastEvents(DateTime lastEventTime)
        {
            throw new NotImplementedException();
        }
    }
}