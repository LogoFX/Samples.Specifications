using AutoMapper;
using Samples.Specifications.Server.Api.Mappers;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Server.Api
{    
    internal sealed class MappingModule : IPlainCompositionModule
    {        
        public void RegisterModule() => Mapper.Initialize(x => x.AddProfile<MappingProfile>());
    }
}
