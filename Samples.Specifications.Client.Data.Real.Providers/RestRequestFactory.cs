using JetBrains.Annotations;
using RestSharp;

namespace Samples.Specifications.Client.Data.Real.Providers
{
    internal interface IRequestFactory
    {
        IRestRequest GetRequest(string route, Method method, object body = null);
    }

    [UsedImplicitly]
    internal sealed class RestRequestFactory : IRequestFactory
    {
        public IRestRequest GetRequest(string route, Method method, object body = null)
        {
            var restRequest = new RestRequest($"api/{route}", method)
            {
                RequestFormat = DataFormat.Json,
                Timeout = 5000
            };

            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");

            if (method == Method.PUT || method == Method.POST)
            {
                restRequest.AddBody(body);
            }

            return restRequest;
        }
    }
}
