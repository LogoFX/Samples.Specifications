using Attest.Testing.Contracts;
using Attest.Testing.EndToEnd;
using Solid.Bootstrapping;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;

namespace Samples.Specifications.Tests.Infra.Launcher
{
    //TODO: Move to packages - Take into account it should not be Integration/E2E-specific
    public class RegisterBootstrappingMiddleware : IMiddleware<IHaveRegistrator>
    {
        public IHaveRegistrator Apply(IHaveRegistrator @object)
        {            
            @object.Registrator                
                .AddSingleton<IStartDynamicApplicationModuleService, StartDynamicApplicationModuleService>()
                .AddSingleton<IStartStaticApplicationModuleService, StartStaticApplicationModuleService>()
                .AddSingleton<ILifecycleService, StaticLifecycleService>()
                .AddSingleton<IStaticSetupService, StaticSetupService>();
            return @object;
        }
    }
}