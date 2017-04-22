using System.IO;
using Samples.Client.Data.Contracts.Dto;
using Samples.Specifications.Server.Storage.NDatabase;

namespace Samples.Specifications.Tests.Steps.Helpers
{
    public class NDatabaseSetupHelper : ISetupHelper
    {
        public void AddWarehouseItem(WarehouseItemDto warehouseItem)
        {
            using (var storage = new Storage())
            {
                storage.Store(warehouseItem);
            }
        }

        public void AddUser(string login, string password)
        {
            using (var storage = new Storage())
            {
                storage.Store(new UserDto
                {
                    Login = login,
                    Password = password
                });
            }
        }

        public void ClearUsers()
        {
            using (var storage = new Storage())
            {
                storage.RemoveAll<UserDto>();
            }
        }

        public void ClearWarehouseItems()
        {
            using (var storage = new Storage())
            {
                storage.RemoveAll<WarehouseItemDto>();
            }
        }

        public void Initialize()
        {
            File.Delete("objects.ndb");
        }
    }    
}