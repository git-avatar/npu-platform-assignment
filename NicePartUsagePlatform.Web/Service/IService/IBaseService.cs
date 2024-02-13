using NicePartUsagePlatform.Web.Models;

namespace NicePartUsagePlatform.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
