using System.Composition;
using AutoMapper;
using LogoFX.Client.Bootstrapping.Adapters.Unity;
using LogoFX.Samples.Specifications.Client.Model.Contracts;
using LogoFX.Samples.Specifications.Client.Model.Mappers;
using Solid.Practices.Modularity;

namespace LogoFX.Samples.Specifications.Client.Model
{
    [Export(typeof(ICompositionModule))]
    class Module : ICompositionModule<UnityContainerAdapter>
    {
        public void RegisterModule(UnityContainerAdapter iocContainer)
        {
            Mapper.Initialize(x => x.AddProfile<MappingProfile>());
            iocContainer.RegisterSingleton<IDataService, DataService>();
            iocContainer.RegisterSingleton<ILoginService, LoginService>();
        }
    }
}
