using Attest.Testing.Core.FakeData.Shared;
using Samples.Specifications.Client.Tests.Integration.Infra.Core;
using Samples.Specifications.Client.Tests.Integration.Infra.Shared;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Fake
{
    internal sealed class StartApplicationService : StartApplicationServiceBase
    {        
        public StartApplicationService(StructureHelper structureHelper)
            :base(structureHelper)
        {     
        }

        protected override void OnArrange()
        {
            BuildersCollectionContext.SerializeBuilders();
        }
    }
}
