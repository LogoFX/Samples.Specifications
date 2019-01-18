using System.Collections.Generic;
using Attest.Testing.Contracts;
using Attest.Testing.EndToEnd;
using Solid.Bootstrapping;
using Solid.Practices.Composition.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;

namespace Samples.Specifications.Tests.Infra.Launcher
{
    //TODO: Move to packages - pat attention that "EndToEnd" should be changed into something else 
    //as the classes are used also in integration tests
    public class UseLifecycleMiddleware<TBootstrapper> : IMiddleware<TBootstrapper>
        where TBootstrapper : class, IHaveRegistrator, IAssemblySourceProvider
    {        
        private readonly List<IMiddleware<TBootstrapper>> _middlewares = new List<IMiddleware<TBootstrapper>>
        {
            new RegisterCollectionMiddleware<TBootstrapper, IDynamicApplicationModule>(),
            new RegisterCollectionMiddleware<TBootstrapper, IStaticApplicationModule>(),
            new RegisterCollectionMiddleware<TBootstrapper, ISetupService>(),
            new RegisterCollectionMiddleware<TBootstrapper, ITeardownService>()
        };

        public TBootstrapper Apply(TBootstrapper @object)
        {                        
            @object.Registrator                
                .AddSingleton<IStartDynamicApplicationModuleService, StartDynamicApplicationModuleService>()
                .AddSingleton<IStartStaticApplicationModuleService, StartStaticApplicationModuleService>()
                .AddSingleton<ILifecycleService, StaticLifecycleService>()
                .AddSingleton<IStaticSetupService, StaticSetupService>();
            MiddlewareApplier.ApplyMiddlewares(@object, _middlewares);
            return @object;
        }        
    }    
}