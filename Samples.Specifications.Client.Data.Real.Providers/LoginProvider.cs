using System;
using System.Linq;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Data.Contracts.Providers;

namespace Samples.Specifications.Client.Data.Real.Providers
{
    class LoginProvider : ILoginProvider
    {
        public void Login(string username, string password)
        {
            using (var storage = new Storage())
            {
                var users = storage.Get<UserDto>();
                if (users.Any(t => t.Login == username && t.Password == password) == false)
                {
                    throw new Exception("Unable to login.");
                }
            }
        }
    }
}