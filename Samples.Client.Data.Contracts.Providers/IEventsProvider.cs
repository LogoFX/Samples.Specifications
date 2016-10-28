﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Samples.Client.Data.Contracts.Dto;

namespace Samples.Client.Data.Contracts.Providers
{
    public interface IEventsProvider
    {
        Task<IEnumerable<EventDto>> GetLastEvents(DateTime lastEventTime);
    }
}