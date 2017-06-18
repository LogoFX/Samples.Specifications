using System.Reflection;
using Samples.Specifications.Tests.Domain;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Tests.Integration.Domain
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterAutomagically(Assembly.LoadFrom("Samples.Specifications.Tests.Domain.dll"),
                Assembly.GetExecutingAssembly());
        }
    }
}
