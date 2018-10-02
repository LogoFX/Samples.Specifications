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

        public WarehouseProvider(RestClient client)
        {
            _client = client;
        }

        IEnumerable<WarehouseItemDto> IWarehouseProvider.GetWarehouseItems()
        {
            var restRequest = new RestRequest("api/warehouse", Method.GET) { RequestFormat = DataFormat.Json };
            var response = _client.Execute<List<WarehouseItemDto>>(restRequest);            
            return response.Data;            
        }

        bool IWarehouseProvider.DeleteWarehouseItem(Guid id)
        {
            var restRequest = new RestRequest($"api/warehouse/{id}", Method.DELETE) { RequestFormat = DataFormat.Json };
            var response = _client.Execute(restRequest);
            return response.StatusCode == HttpStatusCode.OK;
        }

        bool IWarehouseProvider.UpdateWarehouseItem(WarehouseItemDto dto)
        {
            var restRequest = new RestRequest($"api/warehouse/{dto.Id}", Method.PUT) { RequestFormat = DataFormat.Json };            
            restRequest.AddBody(dto);
            var response = _client.Execute(restRequest);
            return response.StatusCode == HttpStatusCode.OK;
        }

        void IWarehouseProvider.CreateWarehouseItem(WarehouseItemDto dto)
        {
            var restRequest = new RestRequest("api/warehouse", Method.POST) { RequestFormat = DataFormat.Json };
            restRequest.AddBody(dto);
            var response = _client.Execute(restRequest);            
        }
    }
}
