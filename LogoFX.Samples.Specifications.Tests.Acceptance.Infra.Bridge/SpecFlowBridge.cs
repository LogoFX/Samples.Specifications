using System.Linq;
using BoDi;
using LogoFX.Bootstrapping;
using LogoFX.Client.Testing.EndToEnd.SpecFlow;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;
using TechTalk.SpecFlow;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Infra.Bridge
{
    /// <summary>
    /// Represents SpecFlow bridge which performs the required registrations
    /// for screen objects and application services
    /// </summary>
    [Binding]
    class SpecFlowBridge : EndToEndTestsBase
    {
        public SpecFlowBridge(IObjectContainer objectContainer)
        {
            var containerAdapter = new ObjectContainerAdapter(objectContainer);
            var bootstrapper = new Bootstrapper(containerAdapter);            
            bootstrapper.Initialize();
            containerAdapter.RegisterContainerAdapterCompositionModules(
                bootstrapper.Modules.OfType<ICompositionModule<IIocContainerRegistrator>>()
                    .Where(t => t.GetType().Namespace.Contains("Providers") == false));           
        }                       
    }
}
