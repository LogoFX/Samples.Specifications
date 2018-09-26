using System.Reflection;
using JetBrains.Annotations;
using Samples.Specifications.Tests.Domain;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.Steps
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator
                .RegisterAutomagically(
                    Assembly.LoadFrom("Samples.Specifications.Tests.Steps.Contracts.dll"),
                    Assembly.GetExecutingAssembly());
        }
    }
}