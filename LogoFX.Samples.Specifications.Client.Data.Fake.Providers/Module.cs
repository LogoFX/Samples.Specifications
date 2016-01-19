using System.ComponentModel.Composition;
using LogoFX.Client.Bootstrapping.Adapters.SimpleInjector;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Dto;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Providers;
using LogoFX.Samples.Specifications.Client.Data.Fake.Containers;
using LogoFX.Samples.Specifications.Client.Data.Fake.ProviderBuilders;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace LogoFX.Samples.Specifications.Client.Data.Fake.Providers
{
    [Export(typeof(ICompositionModule))]
    class Module : ICompositionModule<SimpleInjectorAdapter>
    {
        public void RegisterModule(SimpleInjectorAdapter iocContainer)
        {
            RegisterDataContainers(iocContainer);
            RegisterBuilders(iocContainer);
            RegisterProviders(iocContainer);            
        }

        private static void RegisterDataContainers(IIocContainerRegistrator iocContainer)
        {
            var warehouseContainer = InitializeWarehouseContainer();
            iocContainer.RegisterInstance(warehouseContainer);
        }

        private static IWarehouseContainer InitializeWarehouseContainer()
        {
            var warehouseContainer = new WarehouseContainer();
            warehouseContainer.UpdateWarehouseItems(new []
            {
                new WarehouseItemDto
                {
                    Kind = "PC",
                    Price = 25.43,
                    Quantity = 8
                }
            });
            return warehouseContainer;
        }

        private static void RegisterBuilders(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterInstance(WarehouseProviderBuilder.CreateBuilder());
        }

        private static void RegisterProviders(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterSingleton<IWarehouseProvider, FakeWarehouseProvider>();
        }
    }
}
