﻿using System.ComponentModel.DataAnnotations;

namespace NicePartUsagePlatform.Services.ScoreAPI.Models.Dto
{
    public class ScoreDto
    {
        public int ScoreId { get; set; }
        public int NpuId { get; set; }
        public int UserId { get; set; }
        public int Creativity { get; set; }
        public int Uniqueness { get; set; }
    }
}
