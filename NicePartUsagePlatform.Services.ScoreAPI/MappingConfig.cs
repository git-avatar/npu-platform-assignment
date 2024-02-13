using AutoMapper;
using NicePartUsagePlatform.Services.ScoreAPI.Models;
using NicePartUsagePlatform.Services.ScoreAPI.Models.Dto;

namespace NicePartUsagePlatform.Services.ScoreAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ScoreDto, Score>();
                config.CreateMap<Score, ScoreDto>();
            });
            return mappingConfig;
        }
    }
}
