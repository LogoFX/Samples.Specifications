using System;
using System.Collections.Generic;
using System.Linq;
using Attest.Fake.Builders;
using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Data.Contracts.Providers;

namespace Samples.Specifications.Client.Data.Fake.ProviderBuilders
{    
    public sealed class EventsProviderBuilder : FakeBuilderBase<IEventsProvider>.WithInitialSetup
    {
        private readonly List<EventDto> _events = new List<EventDto>();

        private Timer _timer;
        private readonly Random _rnd = new Random();

        private EventsProviderBuilder()
        {
            _timer = new Timer(OnTimer, null, 1000, 1000);
        }

        ~EventsProviderBuilder()
        {
            var timer = _timer;
            if (timer != null)
            {
                timer.Dispose();
                _timer = null;
            }
        }      

        private void OnTimer(object state)
        {
            if (_rnd.NextDouble() < 0.7)
            {
                return;
            }

            WithEvent($"Sample Message #{_rnd.Next(1, 100)}");
        }

        public static EventsProviderBuilder CreateBuilder()
        {
            return new EventsProviderBuilder();
        }

        protected override IServiceCall<IEventsProvider> CreateServiceCall(
            IHaveNoMethods<IEventsProvider> serviceCallTemplate)
        {
            var setup = serviceCallTemplate
                .AddMethodCallWithResult<DateTime, IEnumerable<EventDto>>(
                    t => t.GetLastEvents(It.IsAny<DateTime>()),
                    (r, lastEventTime) => r.Complete(_events.Where(x => x.Time >= lastEventTime)));
            return setup;
        }

        public void WithEvent(string message)
        {
            var evt = new EventDto
            {
                Time = DateTime.Now,
                Message = message
            };
            _events.Add(evt);
        }
    }
}