using System.ComponentModel.DataAnnotations;

namespace NicePartUsagePlatform.Services.NPUAPI.Models
{
    public class Npu
    {
        [Key]
        public int NpuId { get; set; }
        [Required, MinLength(3), MaxLength(40)]
        public string ElementName { get; set; }
        [Required, MinLength(10), MaxLength(750) ]
        public string Description { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Url(ErrorMessage = "Invalid URL format")]
        public string ImageUrl { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
