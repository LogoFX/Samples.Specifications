using System;
using AutoMapper;
using Samples.Specifications.Server.Domain.Models;
using Samples.Specifications.Server.Host.Data;

namespace Samples.Specifications.Server.Host.Mappers
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateWarehouseMaps();
            CreateUserMaps();
        }

        private void CreateWarehouseMaps()
        {
            CreateDomainObjectMap<WarehouseItemDto, WarehouseItem>();
        }

        private void CreateUserMaps()
        {
            CreateDomainObjectMap<UserDto, User>();
        }

        //TODO: put this piece of functionality into 
        //an external package, e.g. Model.Mapping.AutoMapper
        private void CreateDomainObjectMap<TDto, TModel>()                    
        {
            CreateDomainObjectMap(typeof(TDto), typeof(TModel));
        }

        private void CreateDomainObjectMap(Type dtoType, Type modelType)
        {            
            CreateMap(dtoType, modelType);         
            CreateMap(modelType, dtoType);
        }
    }
}
