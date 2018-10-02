using System;
using System.Collections.Generic;

namespace Samples.Specifications.Client.Data.Fake.Containers
{
    public interface IUserContainer : IDataContainer
    {
        IEnumerable<Tuple<string, string>> Users { get; }
    }

    public sealed class UserContainer : IUserContainer
    {
        private readonly List<Tuple<string, string>> _users = new List<Tuple<string, string>>();
        public IEnumerable<Tuple<string, string>> Users => _users;

        public void UpdateUsers(IEnumerable<Tuple<string, string>> users)
        {
            _users.Clear();
            _users.AddRange(users);
        }
    }
}