using System;
using System.Collections.Generic;
using Samples.Client.Data.Contracts.Dto;

namespace Samples.Client.Data.Contracts.Providers
{
    public interface IEventsProvider
    {
        IEnumerable<EventDto> GetLastEvents(DateTime lastEventTime);
    }
}