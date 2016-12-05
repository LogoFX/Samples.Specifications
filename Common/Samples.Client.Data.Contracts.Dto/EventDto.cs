using System;

namespace Samples.Client.Data.Contracts.Dto
{
    public sealed class EventDto
    {
        public DateTime Time { get; set; }
        public string Message { get; set; }
    }
}