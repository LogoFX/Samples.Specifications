using System;
using System.Threading;
using Attest.Testing.Contracts;
using Samples.Specifications.Tests.Contracts.ScreenObjects;
using Solid.Practices.IoC;

namespace Samples.Specifications.Tests.Steps
{
    public sealed class GeneralSteps
    {
        private readonly IStartLocalApplicationService _startLocalApplicationService;
        private readonly IStartDynamicApplicationModuleService _startDynamicApplicationModuleService;
        private readonly IDependencyResolver _dependencyResolver;
        private readonly IShellScreenObject _shellScreenObject;

        public GeneralSteps(
            IStartLocalApplicationService startLocalApplicationService,
            IStartDynamicApplicationModuleService startDynamicApplicationModuleService,
            IDependencyResolver dependencyResolver,
            IShellScreenObject shellScreenObject)
        {
            _startLocalApplicationService = startLocalApplicationService;
            _startDynamicApplicationModuleService = startDynamicApplicationModuleService;
            _dependencyResolver = dependencyResolver;
            _shellScreenObject = shellScreenObject;
        }

        public void WhenIOpenTheApplication()
        {
            var applicationModules = _dependencyResolver.ResolveAll<IDynamicApplicationModule>();
            foreach (var applicationModule in applicationModules)
            {
                _startDynamicApplicationModuleService.Start(applicationModule);
            }
            _startLocalApplicationService.Start();
        }

        public void WhenICloseTheApplication()
        {
            _shellScreenObject.Close();
        }

        public void WaitFor(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }
    }
}
