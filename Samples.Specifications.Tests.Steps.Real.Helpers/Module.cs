using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.Steps.Helpers
{
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.RegisterSingleton<ISetupHelper, MongoDbSetupHelper>();
        }
    }
}
