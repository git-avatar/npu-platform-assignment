using System.ComponentModel.DataAnnotations;

namespace NicePartUsagePlatform.Services.NPUAPI.Models.Dto
{
    public class NpuDto
    {
        [Required]
        public string ElementName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public IFormFile File { get; set; }
    }
}
