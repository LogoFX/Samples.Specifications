using System;
using Samples.Client.Model.Contracts;

namespace Samples.Client.Model
{
    internal sealed class Event : AppModel, IEvent
    {
        public DateTime Time { get; set; }
        public string Message { get; set; }
    }
}