using AutoMapper;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Samples.Specifications.Server.Api.Mappers;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Server.Api
{
    [UsedImplicitly]
    internal sealed class MappingModule : ICompositionModule<IServiceCollection>
    {
        public void RegisterModule(IServiceCollection dependencyRegistrator)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            dependencyRegistrator.AddSingleton(r => config.CreateMapper());
            dependencyRegistrator.AddSingleton<UserMapper>();
            dependencyRegistrator.AddSingleton<WarehouseMapper>();
        }
    }
}
