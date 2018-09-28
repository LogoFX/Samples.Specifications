using JetBrains.Annotations;
using Samples.Specifications.Tests.Steps.Helpers;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.Steps.Real.Helpers
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.AddSingleton<ISetupHelper, MongoDbSetupHelper>();
        }
    }
}
