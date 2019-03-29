using System;
using Attest.Fake.Conventions;
using JetBrains.Annotations;
using Samples.Client.Data.Contracts.Dto;
using Samples.Specifications.Client.Data.Fake.Containers;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Data.Fake.Providers
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator) => dependencyRegistrator
            .AddInstance(InitializeWarehouseContainer())
            .AddInstance(InitializeUserContainer())
            .RegisterBuilders()
            .RegisterFakeProviders();

        private static IWarehouseContainer InitializeWarehouseContainer()
        {
            var warehouseContainer = new WarehouseContainer();
            warehouseContainer.UpdateWarehouseItems(new[]
            {
                new WarehouseItemDto
                {
                    Id = Guid.NewGuid(),
                    Kind = "PC",
                    Price = 25.43,
                    Quantity = 8
                },

                new WarehouseItemDto
                {
                    Id = Guid.NewGuid(),
                    Kind = "Acme",
                    Price = 10,
                    Quantity = 10
                },

                new WarehouseItemDto
                {
                    Id = Guid.NewGuid(),
                    Kind = "Bacme",
                    Price = 20,
                    Quantity = 3
                },

                new WarehouseItemDto
                {
                    Id = Guid.NewGuid(),
                    Kind = "Exceed",
                    Price = 0.4,
                    Quantity = 100
                },

                new WarehouseItemDto
                {
                    Id = Guid.NewGuid(),
                    Kind = "Acme2",
                    Price = 1,
                    Quantity = 10
                }
            });
            return warehouseContainer;
        }

        private static IUserContainer InitializeUserContainer()
        {
            var userContainer = new UserContainer();
            userContainer.UpdateUsers(new[]
            {
                new Tuple<string, string>("Admin", "pass")
            });
            return userContainer;
        }
    }
}
