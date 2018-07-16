using Caliburn.Micro;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;
using Samples.Specifications.Client.Tests.Integration.Infra.Core;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Shared
{
    public static class RootObjectHelper
    {
        public static void InitializeRootObject(StructureHelper structureHelper, object rootObject)
        {
            var shell = (ShellViewModel)rootObject;
            structureHelper.SetRootObject(shell);
            ScreenExtensions.TryActivate(shell);
        }
    }
}
