using System.Collections.Generic;
using System.Threading.Tasks;
using Samples.Specifications.Server.Domain.Models;

namespace Samples.Specifications.Server.Domain.Services.Storage
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
    }
}