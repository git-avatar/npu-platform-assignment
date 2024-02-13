using System.ComponentModel.DataAnnotations;

namespace NicePartUsagePlatform.Services.ScoreAPI.Models
{
    public class Score
    {
        [Key]
        public int ScoreId { get; set; }
        [Required]
        public int NpuId { get; set; }
        [Required]
        public int UserId { get; set; }
        public int Creativity { get; set; }
        public int Uniqueness { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
