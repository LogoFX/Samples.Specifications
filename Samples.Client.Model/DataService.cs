﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using JetBrains.Annotations;
using LogoFX.Client.Core;
using LogoFX.Core;
using Samples.Client.Data.Contracts.Providers;
using Samples.Client.Model.Contracts;
using Samples.Client.Model.Mappers;

namespace Samples.Client.Model
{
    [UsedImplicitly]
    internal sealed class DataService : NotifyPropertyChangedBase<DataService>, IDataService
    {
        private readonly IWarehouseProvider _warehouseProvider;
        private readonly IEventsProvider _eventsProvider;
        private readonly RangeObservableCollection<IWarehouseItem> _warehouseItems = new RangeObservableCollection<IWarehouseItem>();

        private readonly Timer _timer;
        private DateTime _lastEvenTime;
        private readonly RangeObservableCollection<IEvent> _events =
            new RangeObservableCollection<IEvent>();

        public DataService(IWarehouseProvider warehouseProvider, IEventsProvider eventsProvider)
        {
            _warehouseProvider = warehouseProvider;
            _eventsProvider = eventsProvider;

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += TimerOnElapsed;
            _timer.Start();
        }

        private async void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            await ServiceRunner.RunAsync(() =>
            {
                var events = (_eventsProvider.GetLastEvents(_lastEvenTime))
                    .Select(EventMapper.MapToEvent)
                    .ToList();

                if (events.Count == 0)
                {
                    return;
                }

                var max = events.Max(x => x.Time);
                if (max > _lastEvenTime)
                {
                    _lastEvenTime = max;
                }

                _events.AddRange(events);
            });
        }       

        private async Task GetWarehouseItemsInternal()
        {
            await ServiceRunner.RunAsync(() =>
            {
                var warehouseItems = _warehouseProvider.GetWarehouseItems().Select(WarehouseMapper.MapToWarehouseItem);
                _warehouseItems.Clear();
                _warehouseItems.AddRange(warehouseItems);
            });
            
        }

        IEnumerable<IWarehouseItem> IDataService.WarehouseItems => _warehouseItems;

        async Task IDataService.GetWarehouseItemsAsync()
        {
            await ServiceRunner.RunAsync(GetWarehouseItemsInternal);
        }

        async Task<IWarehouseItem> IDataService.NewWarehouseItemAsync()
        {
            await Task.Delay(1000);
            return new WarehouseItem("New Kind", 0d, 1)
            {
                IsNew = true
            };
        }

        async Task IDataService.SaveWarehouseItemAsync(IWarehouseItem item)
        {
            var dto = WarehouseMapper.MapToWarehouseDto(item);
            if (item.IsNew)
            {
                await ServiceRunner.RunAsync(() => _warehouseProvider.CreateWarehouseItem(dto));
            }
            else
            {
                await ServiceRunner.RunAsync(() => _warehouseProvider.UpdateWarehouseItem(dto));
            }            
        }

        async Task IDataService.DeleteWarehouseItemAsync(IWarehouseItem item)
        {
            await ServiceRunner.RunAsync(() =>
             {
                 _warehouseProvider.DeleteWarehouseItem(item.Id);
                 _warehouseItems.Remove(item);
             });
        }

        void IDataService.StartEventMonitoring()
        {
            _lastEvenTime = DateTime.Now;
            _timer.Start();
            NotifyOfPropertyChange(() => EventMonitoringStarted);
        }

        void IDataService.StopEventMonitoring()
        {
            _timer.Stop();
            NotifyOfPropertyChange(() => EventMonitoringStarted);
        }
        
        async Task IDataService.ClearEventsAsync()
        {
            await Task.Delay(400);
            _events.Clear();
            await Task.Delay(300);
        }

        IEnumerable<IEvent> IDataService.Events => _events;

        public bool EventMonitoringStarted => _timer.Enabled;
    }
}
