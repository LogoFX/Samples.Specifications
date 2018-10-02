using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Data.Contracts.Providers;

namespace Samples.Specifications.Client.Data.Real.Providers
{
    internal sealed class WarehouseProvider : IWarehouseProvider
    {
        private readonly RestClient _client;
        private readonly IRequestFactory _requestFactory;

        public WarehouseProvider(
            RestClient client, 
            IRequestFactory requestFactory)
        {
            _client = client;
            _requestFactory = requestFactory;
        }

        IEnumerable<WarehouseItemDto> IWarehouseProvider.GetWarehouseItems()
        {
            var restRequest = _requestFactory.GetRequest("warehouse", Method.GET);
            var response = _client.Execute<List<WarehouseItemDto>>(restRequest);            
            return response.Data;            
        }

        bool IWarehouseProvider.DeleteWarehouseItem(Guid id)
        {
            var restRequest = _requestFactory.GetRequest($"warehouse/{id}", Method.DELETE);
            var response = _client.Execute(restRequest);
            return response.StatusCode == HttpStatusCode.OK;
        }

        bool IWarehouseProvider.UpdateWarehouseItem(WarehouseItemDto dto)
        {
            var restRequest = _requestFactory.GetRequest($"warehouse/{dto.Id}", Method.PUT, dto);            
            var response = _client.Execute(restRequest);
            return response.StatusCode == HttpStatusCode.OK;
        }

        void IWarehouseProvider.CreateWarehouseItem(WarehouseItemDto dto)
        {
            var restRequest = _requestFactory.GetRequest("warehouse", Method.POST, dto);            
            var response = _client.Execute(restRequest);            
        }
    }
}
