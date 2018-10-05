using System.Reflection;
using Attest.Testing.Contracts;
using JetBrains.Annotations;
using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.Integration;
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
                .AddSingleton<IStartClientApplicationService, StartClientApplicationService>()                
                .AddSingleton<ITeardownService, TeardownService>();
        }
    }
}
