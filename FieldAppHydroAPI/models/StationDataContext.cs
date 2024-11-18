using Microsoft.EntityFrameworkCore;

namespace StationDataApi.Models
{
    public class StationDataContext : DbContext
    {
        public DbSet<StationData> StationData { get; set; }
        public DbSet<PersonnelLookupData> PersonnelLookupData { get; set; }

        public StationDataContext(DbContextOptions<StationDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StationData>().ToTable("TestTable", schema: "head");

            modelBuilder.Entity<PersonnelLookupData>().ToTable("Lookup", schema: "Personnel");
            
        }
    }
}

