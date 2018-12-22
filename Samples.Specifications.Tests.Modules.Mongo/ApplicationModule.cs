using System;
using System.Threading.Tasks;
using Attest.Testing.Contracts;
using JetBrains.Annotations;
using Samples.Specifications.Tests.Contracts;

namespace Samples.Specifications.Tests.Modules.Mongo
{
    [UsedImplicitly]
    internal sealed class MongoApplicationModule : IStaticApplicationModule
    {
        private readonly IProcessManagementService _processManagementService;        
        private const string MongoDbService = @"cd C:\\Program Files\\MongoDB\\Server\\3.4\\bin\\&mongod";
        private const string MongoDbRoot = @"c:\\data\\db";

        public MongoApplicationModule(IProcessManagementService processManagementService)
        {
            _processManagementService = processManagementService;            
        }

        public string Id => "Mongo";
        public string RelativePath => string.Empty;

        public int Start()
        {           
            var handle = _processManagementService.Start(MongoDbService,$"--dbpath {MongoDbRoot}");
            //TODO: Wait while the process starts - Application.WaitWhileBusy()...            
            Task.Delay(TimeSpan.FromSeconds(5)).Wait();
            return handle;
        }

        public void Stop(int handle)
        {
            _processManagementService.Stop(handle);
        }
    }
}
