using Microsoft.EntityFrameworkCore;

namespace StationDataApi.Models
{
    public class StationDetailsContext : DbContext
    {
        public DbSet<StationDetails> StationDetails { get; set; }

        public StationDetailsContext(DbContextOptions<StationDetailsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StationDetails>().ToTable("StationDetails", schema: "station"); // Replace with your actual table name
        }
    }
}
