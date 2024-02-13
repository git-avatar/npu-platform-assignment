using System.ComponentModel.DataAnnotations;

namespace NicePartUsagePlatform.Services.NPUAPI.Models.Dto
{
    public class NpuListDto
    {
        public int NpuId { get; set; }
        public string ElementName { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public string ImageUrl { get; set; } 
    }
}
