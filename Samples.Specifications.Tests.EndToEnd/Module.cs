using System.Reflection;
using JetBrains.Annotations;
using LogoFX.Client.Testing.Contracts;
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
                .AddSingleton<IApplicationPathWrapper, ApplicationPathWrapper>()
                .AddSingleton<StructureHelper, StructureHelper>()
                .AddSingleton<IApplicationFacade, ApplicationFacade>()
                .AddSingleton<ITeardownService, TeardownService>();
        }
    }
}
