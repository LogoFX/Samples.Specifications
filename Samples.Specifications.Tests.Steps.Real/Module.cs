using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.Steps
{
    class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.AddSingleton<IGivenLoginSteps, GivenLoginSteps>()
                .AddSingleton<IGivenMainSteps, GivenMainSteps>();
        }       
    }
}
