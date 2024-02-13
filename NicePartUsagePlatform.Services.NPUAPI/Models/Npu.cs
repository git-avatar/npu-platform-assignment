using System.ComponentModel.DataAnnotations;

namespace NicePartUsagePlatform.Services.NPUAPI.Models
{
    public class Npu
    {
        [Key]
        public int NpuId { get; set; }
        [Required]
        public string ElementName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public string ImageUrl { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
