using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Data.Contracts.Providers;

namespace Samples.Specifications.Client.Data.Real.Providers
{
    class WarehouseProvider : IWarehouseProvider
    {
        private readonly RestClient _client;

        public WarehouseProvider()
        {
            _client = new RestClient("http://localhost:32064");            
        }

        public IEnumerable<WarehouseItemDto> GetWarehouseItems()
        {
            var restRequest = new RestRequest("api/warehouse", Method.GET) { RequestFormat = DataFormat.Json };
            var response = _client.Execute<List<WarehouseItemDto>>(restRequest);            
            return response.Data;            
        }

        public bool DeleteWarehouseItem(Guid id)
        {
            var restRequest = new RestRequest($"api/warehouse/{id}", Method.DELETE) { RequestFormat = DataFormat.Json };
            var response = _client.Execute(restRequest);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public bool UpdateWarehouseItem(WarehouseItemDto dto)
        {
            var restRequest = new RestRequest($"api/warehouse/{dto.Id}", Method.PUT) { RequestFormat = DataFormat.Json };            
            restRequest.AddBody(dto);
            var response = _client.Execute(restRequest);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public void CreateWarehouseItem(WarehouseItemDto dto)
        {
            var restRequest = new RestRequest($"api/warehouse", Method.POST) { RequestFormat = DataFormat.Json };
            restRequest.AddBody(dto);
            var response = _client.Execute(restRequest);            
        }
    }
}
