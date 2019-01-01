using System.Reflection;
using JetBrains.Annotations;
using RestSharp;
using Samples.Client.Data.Contracts.Providers;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Data.Real.Providers
{    
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        //TODO: To be put into config
        private const string ServerEndPoint = "http://localhost:32064";

        public void RegisterModule(IDependencyRegistrator dependencyRegistrator) => dependencyRegistrator
            .RegisterAutomagically(
                Assembly.LoadFrom(AssemblyInfo.AssemblyName),
                Assembly.GetExecutingAssembly())
            .AddSingleton<IRequestFactory, RestRequestFactory>()
            .AddSingleton(() => new RestClient(ServerEndPoint));
    }
}
