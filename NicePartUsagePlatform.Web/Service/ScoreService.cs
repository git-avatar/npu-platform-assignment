using NicePartUsagePlatform.Web.Models;
using NicePartUsagePlatform.Web.Service.IService;
using NicePartUsagePlatform.Web.Utility;

namespace NicePartUsagePlatform.Web.Service
{
    public class ScoreService : IScoreService
    {
        private readonly IBaseService _baseService;
        public ScoreService(IBaseService baseService)
        {
            _baseService = baseService;   
        }

        public async Task<ResponseDto?> CreateScoreAsync(ScoreDto scoreDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = scoreDto,
                Url = SD.ScoreAPIBase + "/api/score"
            });
        }

        public async Task<ResponseDto?> DeleteScoreAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ScoreAPIBase + "/api/score/" + id
            });
        }

        public async Task<ResponseDto?> GetAllScoreAsync()
        {
            return await _baseService.SendAsync(new RequestDto(){
                ApiType = SD.ApiType.GET,
                Url = SD.ScoreAPIBase+"/api/score"
            });
        }

        public async Task<ResponseDto?> GetScoreAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ScoreAPIBase + "/api/score/" + id
            });
        }

        public async Task<ResponseDto?> UpdateScoreAsync(ScoreDto scoreDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = scoreDto,
                Url = SD.ScoreAPIBase + "/api/score"
            });
        }
    }
}
