using Samples.Specifications.Client.Tests.Integration.Infra.Core;
using Samples.Specifications.Client.Tests.Integration.Infra.Shared;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Real
{
    internal sealed class StartApplicationService : StartApplicationServiceBase
    {
        public StartApplicationService(StructureHelper structureHelper)
            : base(structureHelper)
        {
        }        
    }
}
