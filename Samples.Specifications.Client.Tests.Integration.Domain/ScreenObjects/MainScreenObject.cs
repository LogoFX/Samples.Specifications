using Samples.Specifications.Client.Tests.Integration.Infra.Core;
using Samples.Specifications.Tests.Domain.ScreenObjects;

namespace Samples.Specifications.Client.Tests.Integration.Domain.ScreenObjects
{
    internal class MainScreenObject : IMainScreenObject
    {
        public StructureHelper StructureHelper { get; set; }

        public MainScreenObject(StructureHelper structureHelper)
        {
            StructureHelper = structureHelper;
        }

        public bool IsActive()
        {
            var main = StructureHelper.GetMain();
            return main.IsActive;
        }
    }
}