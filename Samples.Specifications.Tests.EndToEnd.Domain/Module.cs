using System.Reflection;
using JetBrains.Annotations;
using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd.White;
using Samples.Specifications.Tests.Domain;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {            
            dependencyRegistrator
                .RegisterAutomagically(
                Assembly.LoadFrom("Samples.Specifications.Tests.Domain.dll"),
                Assembly.GetExecutingAssembly())
                .AddSingleton<IExecutableWrapper, ExecutableWrapper>()
                .AddSingleton<StructureHelper, StructureHelper>()
                .AddSingleton<IApplicationFacade, ApplicationFacade>()
                .AddSingleton<ITeardownService, TeardownService>();
        }
    }
}
