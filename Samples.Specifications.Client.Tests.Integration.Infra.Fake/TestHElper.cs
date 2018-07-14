using Caliburn.Micro;
using Samples.Client.Model.Shared;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Fake
{
    public static class TestHelper
    {
        public static void AfterTeardown()
        {
            UserContext.Current = null;
            AssemblySource.Instance.Clear();
        }
    }
}
