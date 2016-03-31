using AutoMapper;
using JetBrains.Annotations;
using LogoFX.Samples.Specifications.Client.Model.Mappers;
using Solid.Practices.Modularity;

namespace LogoFX.Samples.Specifications.Client.Model
{
    [UsedImplicitly]
    class MappingModule : IPlainCompositionModule
    {
        public void RegisterModule()
        {
            Mapper.Initialize(x => x.AddProfile<MappingProfile>());
        }
    }
}