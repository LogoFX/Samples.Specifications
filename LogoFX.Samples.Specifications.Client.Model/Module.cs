using System.ComponentModel.Composition;
using AutoMapper;
using LogoFX.Client.Bootstrapping.Adapters.SimpleInjector;
using LogoFX.Samples.Specifications.Client.Model.Contracts;
using LogoFX.Samples.Specifications.Client.Model.Mappers;
using Solid.Practices.Modularity;

namespace LogoFX.Samples.Specifications.Client.Model
{
    [Export(typeof(ICompositionModule))]
    class Module : ICompositionModule<SimpleInjectorAdapter>
    {
        public void RegisterModule(SimpleInjectorAdapter iocContainer)
        {
            Mapper.Initialize(x => x.AddProfile<MappingProfile>());
            iocContainer.RegisterSingleton<IDataService, DataService>();
        }
    }
}
