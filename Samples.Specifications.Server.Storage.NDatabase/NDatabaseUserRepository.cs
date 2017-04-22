using System.Collections.Generic;
using System.Linq;
using Samples.Client.Data.Contracts.Dto;
using Samples.Specifications.Server.Storage.Contracts;
using Samples.Specifications.Server.Storage.Contracts.Models;

namespace Samples.Specifications.Server.Storage.NDatabase
{
    //TODO: not operable yet
    class NDatabaseUserRepository : IUserRepository
    {
        public IEnumerable<User> GetAll()
        {
            using (var storage = new Storage())
            {
                return storage.Get<UserDto>().Select(t => new User
                {
                    Login = t.Login,
                    Password = t.Password
                });
            }
        }
    }
}
