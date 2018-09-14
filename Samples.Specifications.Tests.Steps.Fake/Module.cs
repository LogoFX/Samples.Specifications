using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.Steps
{
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.AddSingleton<IGivenLoginSteps, GivenLoginSteps>()
                .AddSingleton<IGivenMainSteps, GivenMainSteps>();
        }
    }
}