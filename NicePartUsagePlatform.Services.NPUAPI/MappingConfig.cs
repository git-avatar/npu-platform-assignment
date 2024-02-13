using AutoMapper;
using NicePartUsagePlatform.Services.NPUAPI.Models;
using NicePartUsagePlatform.Services.NPUAPI.Models.Dto;

namespace NicePartUsagePlatform.Services.NPUAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<NpuDto, Npu>();
                config.CreateMap<Npu, NpuDto>();
                config.CreateMap<Npu, NpuListDto>();
            });
            return mappingConfig;
        }
    }
}