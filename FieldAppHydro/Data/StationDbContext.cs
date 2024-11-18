
using Microsoft.EntityFrameworkCore;

namespace FieldAppHydro.Data

{
    public class StationDbContext : DbContext
    {
        public StationDbContext(DbContextOptions<StationDbContext> options)
            : base(options)
        {
        }

        public DbSet<StationData> StationData { get; set; }

        
    }
}