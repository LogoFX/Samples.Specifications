using System.Reflection;
using JetBrains.Annotations;
using LogoFX.Client.Testing.Contracts;
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
                Assembly.LoadFrom("Samples.Specifications.Tests.Contracts.dll"),
                Assembly.GetExecutingAssembly())
                .AddSingleton<ITeardownService, TeardownService>();
        }
    }
}
