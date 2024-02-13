using NicePartUsagePlatform.Web.Models;

namespace NicePartUsagePlatform.Web.Service.IService
{
    public interface IScoreService
    {
        Task<ResponseDto?> GetScoreAsync(int id);
        Task<ResponseDto?> GetAllScoreAsync();
        Task<ResponseDto?> CreateScoreAsync(ScoreDto scoreDto);
        Task<ResponseDto?> UpdateScoreAsync(ScoreDto scoreDto);
        Task<ResponseDto?> DeleteScoreAsync(int id);
    }
}
