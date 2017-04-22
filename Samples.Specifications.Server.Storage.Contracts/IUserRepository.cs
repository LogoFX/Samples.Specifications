using System.Collections.Generic;
using Samples.Specifications.Server.Domain.Models;

namespace Samples.Specifications.Server.Storage.Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
    }
}