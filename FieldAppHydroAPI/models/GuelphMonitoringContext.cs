using Microsoft.EntityFrameworkCore;

namespace StationDataApi.Models
{
    public class GuelphNetworkContext : DbContext
    {
        public DbSet<StationDetails> GuelphNetwork { get; set; }

        public DbSet<ElevationData> GuelphNetworkElevation { get; set; }
 

        public GuelphNetworkContext(DbContextOptions<GuelphNetworkContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StationDetails>().ToTable("StationDetails", schema: "station");
            
            modelBuilder.Entity<ElevationData>().ToTable("ElevationSurveyData", schema: "station"); // Replace with your actual table name

        }
    }
}
