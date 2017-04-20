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
            throw new NotImplementedException();
        }

        public void SaveWarehouseItem(WarehouseItemDto dto)
        {
            throw new NotImplementedException();
        }

        class ResponseBase
        {
            internal Exception Error { get; set; }
        }

        class WarehouseItemsResponse : ResponseBase
        {
            public WarehouseItemDto[] WarehouseItems { get; set; }
        }

        private T GetResponse<T>(RestRequest restRequest) where T : new()
        {
            T response = default(T);
            var restResponse = _client.Execute<T>(restRequest);            
            if (restResponse.ContentLength > 0)
            {
                response = restResponse.Data;
                if (response != null && restResponse.StatusCode != HttpStatusCode.OK)
                {                    
                    if (restResponse.ErrorMessage == null)
                    {
                        //response.Error = restResponse.ErrorException ?? new Exception(restResponse.Content);
                    }
                }
            }
            return response;
        }
    }
}
