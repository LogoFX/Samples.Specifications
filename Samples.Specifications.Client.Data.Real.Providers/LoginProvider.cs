using System.Threading.Tasks;
using Samples.Client.Data.Contracts.Providers;

namespace Samples.Specifications.Client.Data.Real.Providers
{
    class LoginProvider : ILoginProvider
    {
        public Task Login(string username, string password)
        {
            return Task.Run(() =>
            {
                // TODO: Add login logic here
            });
        }
    }
}