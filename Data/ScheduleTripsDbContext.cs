using Microsoft.EntityFrameworkCore;
using Save__plan_your_trips.Models;

namespace Save__plan_your_trips.Data
{
    public class ScheduleTripsDbContext : DbContext
    {
        public ScheduleTripsDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Album> Albums { get; set; }
    }
}
