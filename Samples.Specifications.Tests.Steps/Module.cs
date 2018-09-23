using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.Steps
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            RegisterStepsAutomagically(dependencyRegistrator, Assembly.GetExecutingAssembly());
        }

        private static void RegisterStepsAutomagically(IDependencyRegistrator dependencyRegistrator, Assembly assembly)
        {
            foreach (var type in assembly.DefinedTypes.Where(t => t.Name.EndsWith("Steps")))
            {
                dependencyRegistrator.RegisterSingleton(type, type);
            }
        }
    }
}
