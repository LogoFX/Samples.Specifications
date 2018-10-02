using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Data.Contracts.Providers;

namespace Samples.Specifications.Client.Data.Real.Providers
{
    internal sealed class LoginProvider : ILoginProvider
    {
        private readonly IRequestFactory _requestFactory;
        private readonly RestClient _client;

        public LoginProvider(
            RestClient client, 
            IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;
            _client = client;
        }

        void ILoginProvider.Login(string username, string password)
        {
            //TODO: very naive ))
            var restRequest = _requestFactory.GetRequest("user", Method.GET);
            IRestResponse<List<UserDto>> response;
            try
            {
                response = _client.Execute<List<UserDto>>(restRequest);                
            }
            catch (Exception e)
            {                
                throw new Exception("Unable to login.");
            }

            var matchingUser = response.Data?.SingleOrDefault(t => t.Login == username);
            if (matchingUser == null)
            {
                throw new Exception("Login not found.");
            }

            if (matchingUser.Password != password)
            {
                throw new Exception("Unable to login.");
            }           
        }
    }
}