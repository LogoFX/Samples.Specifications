using System.Threading.Tasks;
using JetBrains.Annotations;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Providers;
using LogoFX.Samples.Specifications.Client.Model.Contracts;
using LogoFX.Samples.Specifications.Client.Model.Shared;
using Solid.Practices.Scheduling;

namespace LogoFX.Samples.Specifications.Client.Model
{
    [UsedImplicitly]
    class LoginService : ILoginService
    {
        private readonly ILoginProvider _loginProvider;

        public LoginService(ILoginProvider loginProvider)
        {
            _loginProvider = loginProvider;
        }

        public async Task LoginAsync(string username, string password)
        {
            await TaskRunner.RunAsync(async () =>
            {
                await _loginProvider.Login(username, password);
                UserContext.Current = new User(username);
            });
        }
    }
}