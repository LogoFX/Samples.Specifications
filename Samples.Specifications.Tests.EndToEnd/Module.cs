using System.Reflection;
using Attest.Testing.Contracts;
using JetBrains.Annotations;
using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd;
using LogoFX.Client.Testing.EndToEnd.White;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {            
            dependencyRegistrator                
                .RegisterAutomagically(
                Assembly.LoadFrom("Samples.Specifications.Tests.Contracts.dll"),
                Assembly.GetExecutingAssembly())
                .AddSingleton<IApplicationPathInfo, ApplicationPathInfo>()
                .AddSingleton<StructureHelper, StructureHelper>()
                .AddSingleton<IApplicationFacade, ApplicationFacade>()
                .AddSingleton<IStartClientApplicationService, StartClientApplicationService>()
                .AddSingleton<ITeardownService, TeardownService>();
        }
    }
}
