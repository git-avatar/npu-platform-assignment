using Microsoft.EntityFrameworkCore;
using NicePartUsagePlatform.Services.NPUAPI.Models;

namespace NicePartUsagePlatform.Services.NPUAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Npu> Npus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
