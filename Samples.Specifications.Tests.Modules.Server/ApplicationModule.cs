using Attest.Testing.Contracts;
using Attest.Testing.EndToEnd;
using JetBrains.Annotations;
using Samples.Specifications.Tests.Contracts;

namespace Samples.Specifications.Tests.Modules.Server
{
    [UsedImplicitly]
    internal sealed class WebServerModule : IDynamicApplicationModule
    {
        private readonly IStartApplicationService _startApplicationService;
        private readonly IApplicationPathInfo _applicationPathInfo;
        private readonly IApplicationFacade _applicationFacade;

        public WebServerModule(IProcessManagementService processManagementService)
        {
            _applicationFacade = new ApplicationFacade(processManagementService);
            _startApplicationService = new StartApplicationService.WithRealProviders(_applicationFacade);
            _applicationPathInfo = new ApplicationPathInfo();
        }

        public string Id => "WebServer";
        public string RelativePath => _applicationPathInfo.RelativePath;

        public void Start()
        {
            _startApplicationService.Start(_applicationPathInfo.Executable);
        }

        public void Stop()
        {
            _applicationFacade.Stop();
        }
    }
}