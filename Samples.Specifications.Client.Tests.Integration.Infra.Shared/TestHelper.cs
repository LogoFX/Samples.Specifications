using Samples.Client.Model.Shared;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Shared
{
    public static class TestHelper
    {
        public static void AfterTeardown()
        {
            UserContext.Current = null;                        
            LogoFX.Client.Testing.Shared.Caliburn.Micro.TestHelper.Teardown();            
        }
    }
}
