using System.IO;
using Samples.Client.Data.Contracts.Dto;
using Samples.Specifications.Server.Storage.NDatabase;

namespace Samples.Specifications.Tests.Steps.Helpers
{
    public sealed class NDatabaseSetupHelper : ISetupHelper
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

        public void Initialize()
        {
            File.Delete("objects.ndb");
        }
    }    
}