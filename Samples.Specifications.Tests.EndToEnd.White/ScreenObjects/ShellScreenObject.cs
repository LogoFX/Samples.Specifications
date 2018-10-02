using Samples.Specifications.Tests.Contracts.ScreenObjects;

namespace Samples.Specifications.Tests.EndToEnd.ScreenObjects
{
    internal sealed class ShellScreenObject : IShellScreenObject
    {
        public StructureHelper StructureHelper { get; set; }

        public ShellScreenObject(StructureHelper structureHelper)
        {
            StructureHelper = structureHelper;
        }

        public void Close()
        {            
            var shell = StructureHelper.GetShell();
            shell.Close();
        }
    }
}
