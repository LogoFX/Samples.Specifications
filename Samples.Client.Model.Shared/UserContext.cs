using Samples.Client.Model.Contracts;

namespace Samples.Client.Model.Shared
{
    public static class UserContext
    {
        public static IUser Current { get; set; }
    }
}
