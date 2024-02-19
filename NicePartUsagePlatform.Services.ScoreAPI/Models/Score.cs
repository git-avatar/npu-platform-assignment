using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Range(1, 10)]
        public int Creativity { get; set; }
        [Range(1, 10)]
        public int Uniqueness { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
