using AutoMapper;
using BackendApi.Models;
using BackendApi.Models.Dao;

namespace BackendApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CrudDto, Crud>();
                config.CreateMap<Crud, CrudDto>();
            });

            return mappingConfig;
        } 
    }
}
