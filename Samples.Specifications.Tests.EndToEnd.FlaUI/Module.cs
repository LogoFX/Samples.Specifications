using System.Reflection;
using Attest.Testing.Contracts;
using JetBrains.Annotations;
using LogoFX.Client.Testing.Contracts;
using Samples.Specifications.Tests.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator) => dependencyRegistrator                
            .RegisterAutomagically(
                Assembly.LoadFrom(AssemblyInfo.AssemblyName),
                Assembly.GetExecutingAssembly())                
            .AddSingleton<StructureHelper, StructureHelper>()
            .AddSingleton<IApplicationFacade, ApplicationFacade>()                
            .AddSingleton<ITeardownService, TeardownService>();
    }
}
