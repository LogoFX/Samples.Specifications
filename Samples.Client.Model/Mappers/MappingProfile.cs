using System;
using AutoMapper;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Model.Contracts;

namespace Samples.Client.Model.Mappers
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateWarehouseMaps();
            CreateEventMaps();
        }        

        private void CreateWarehouseMaps()
        {
            CreateDomainObjectMap<WarehouseItemDto, IWarehouseItem, WarehouseItem>();
        }

        private void CreateEventMaps()
        {
            CreateDomainObjectMap<EventDto, IEvent, Event>();
        }

        //TODO: put this piece of functionality into 
        //an external package, e.g. Model.Mapping.AutoMapper
        private void CreateDomainObjectMap<TDto, TContract, TModel>()
                    where TModel : TContract
                    where TContract : class
        {
            CreateDomainObjectMap(typeof (TDto), typeof (TContract), typeof (TModel));
        }


        private void CreateDomainObjectMap(Type dtoType, Type contractType, Type modelType)
        {
            CreateMap(dtoType, contractType).As(modelType);
            CreateMap(dtoType, modelType);
            CreateMap(contractType, dtoType);
            CreateMap(modelType, dtoType);
        }
    }
}
