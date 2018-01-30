using System.Reflection;
using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd.White;
using Samples.Specifications.Tests.Domain;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {            
            dependencyRegistrator
                .RegisterAutomagically(
                Assembly.LoadFrom("Samples.Specifications.Tests.Domain.dll"),
                Assembly.GetExecutingAssembly())
                .AddSingleton<IExecutableContainer, ExecutableContainer>()
                .AddSingleton<StructureHelper, StructureHelper>()
                .AddSingleton<IApplicationFacade, ApplicationFacade>();            
        }
    }
}
