using Samples.Client.Model.Contracts;

namespace Samples.Client.Model
{
    internal sealed class User : AppModel, IUser
    {
        public User(string username)
        {
            Username = username;
        }

        public string Username { get; }
    }
}