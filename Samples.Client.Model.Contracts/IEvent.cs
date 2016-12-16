using System;

namespace Samples.Client.Model.Contracts
{
    public interface IEvent : IAppModel
    {
        DateTime Time { get; }
        string Message { get; }
    }
}