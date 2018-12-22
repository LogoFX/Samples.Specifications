using System;
using System.Threading.Tasks;
using Attest.Testing.Contracts;
using JetBrains.Annotations;
using Samples.Specifications.Tests.Contracts;

namespace Samples.Specifications.Tests.Modules.Server
{
    [UsedImplicitly]
    internal sealed class ApplicationFacade : IApplicationFacade
    {
        private readonly IProcessManagementService _processManagementService;
        private int _applicationHandle;

        public ApplicationFacade(IProcessManagementService processManagementService) =>
            _processManagementService = processManagementService;

        public void Start(string startupPath)
        {
            _applicationHandle = _processManagementService.Start("dotnet", $"{startupPath}");
            //TODO: Wait while the process starts - Application.WaitWhileBusy()...            
            Task.Delay(TimeSpan.FromSeconds(5)).Wait();
        }

        public void Stop() => _processManagementService.Stop(_applicationHandle);
    }
}