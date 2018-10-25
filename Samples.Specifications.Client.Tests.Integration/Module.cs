using System.Reflection;
using Attest.Testing.Contracts;
using Attest.Testing.Integration;
using JetBrains.Annotations;
using Samples.Specifications.Tests.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Tests.Integration
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator
                .RegisterAutomagically(
                Assembly.LoadFrom(AssemblyInfo.AssemblyName),
                Assembly.GetExecutingAssembly())
                .AddSingleton<IStartLocalApplicationService, StartLocalApplicationService>()                
                .AddSingleton<ITeardownService, TeardownService>();
        }
    }
}
