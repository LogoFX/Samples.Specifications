using AutoMapper;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Model.Contracts;

namespace Samples.Client.Model.Mappers
{
    internal static class EventMapper
    {
        public static IEvent MapToEvent(EventDto eventDto)
        {
            return Mapper.Map<Event>(eventDto);
        }
    }
}