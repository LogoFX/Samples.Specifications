using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.Unity;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Shared
{
    public class TestBootstrapper : TestBootstrapperContainerBase<UnityContainerAdapter>
        .WithRootObject<ShellViewModel>
    {
        public TestBootstrapper() :
            base(new UnityContainerAdapter(), new BootstrapperCreationOptions
            {
                UseApplication = false,
                ReuseCompositionInformation = true
            })
        {
            
        }

        public override string[] Prefixes
        {
            get
            {
                return new[] { "Samples.Universal.Client.Presentation", "Samples.Client.Model", "Samples.Client.Data", "Samples.Universal.Client.Tests", "Samples.Client.Tests" };
            }
        }
    }
}