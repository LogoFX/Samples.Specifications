using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Data.Contracts.Providers;

namespace Samples.Specifications.Client.Data.Real.Providers
{
    class LoginProvider : ILoginProvider
    {
        private readonly RestClient _client;

        public LoginProvider()
        {
            _client = new RestClient("http://localhost:32064");
        }

        public void Login(string username, string password)
        {
            //TODO: very naive ))
            var restRequest = new RestRequest("api/user", Method.GET) { RequestFormat = DataFormat.Json };
            IRestResponse<List<UserDto>> response;
            try
            {
                response = _client.Execute<List<UserDto>>(restRequest);                
            }
            catch (Exception e)
            {                
                throw new Exception("Unable to login.");
            }

            if (response.Data?.Any(t => t.Login == username && t.Password == password) == false)
            {
                throw new Exception("Login not found.");
            }

            //using (var storage = new Storage())
            //{
            //    var users = storage.Get<UserDto>();
            //    if (users.Any(t => t.Login == username && t.Password == password) == false)
            //    {
            //        throw new Exception("Unable to login.");
            //    }
            //}
        }
    }
}