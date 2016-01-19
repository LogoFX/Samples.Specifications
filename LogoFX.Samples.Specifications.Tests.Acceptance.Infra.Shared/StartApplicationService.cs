using LogoFX.Client.Tests.Integration;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Infra.Shared
{
    public class StartApplicationService : StartApplicationServiceBase
    {
        protected override void OnStart(object rootObject)
        {
            var shell = (ShellViewModel)rootObject;
            StructureHelper.SetRootObject(shell);
            ScreenExtensions.TryActivate(shell);            
        }
    }
}
