using Microsoft.EntityFrameworkCore;
using NicePartUsagePlatform.Services.ScoreAPI.Models;

namespace NicePartUsagePlatform.Services.ScoreAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seeding the table with one initial record
            modelBuilder.Entity<Score>().HasData(new Score
            {
                ScoreId = 1,
                NpuId = 1,
                UserId = 1,
                Creativity = 8,
                Uniqueness = 7,
                CreatedDate = DateTimeOffset.Now
            });
        }
    }
}
