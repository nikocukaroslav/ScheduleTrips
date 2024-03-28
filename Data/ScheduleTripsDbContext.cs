using Microsoft.EntityFrameworkCore;
using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Data
{
    public class ScheduleTripsDbContext : DbContext
    {
        public ScheduleTripsDbContext(DbContextOptions<ScheduleTripsDbContext> options) : base(options)
        {
        }
        public DbSet<Album> Album { get; set; }
    }
}
