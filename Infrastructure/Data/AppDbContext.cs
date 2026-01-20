using Microsoft.EntityFrameworkCore;
using vendsys_api.Domain.Entities;


namespace vendsys_api.Infrastructure.Data
{

    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<DexMeter> DexMeters => Set<DexMeter>();
        public DbSet<DexLaneMeter> DexLaneMeters => Set<DexLaneMeter>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DexMeter>()
                .HasIndex(x => new { x.MachineId, x.DexDateTime })
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
