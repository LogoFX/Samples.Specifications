using System.Linq;
using System.Reflection;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.Steps
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            RegisterStepsAutomagically(iocContainer, Assembly.GetExecutingAssembly());
        }

        private static void RegisterStepsAutomagically(IIocContainerRegistrator iocContainer, Assembly assembly)
        {
            foreach (var type in assembly.DefinedTypes.Where(t => t.Name.EndsWith("Steps")))
            {
                iocContainer.RegisterSingleton(type, type);
            }
        }
    }
}
