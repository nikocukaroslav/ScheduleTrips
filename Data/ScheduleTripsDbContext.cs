using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Save__plan_your_trips.Models.Domain;

namespace Save__plan_your_trips.Data
{
    public class ScheduleTripsDbContext : IdentityDbContext
    {
        public ScheduleTripsDbContext(DbContextOptions<ScheduleTripsDbContext> options) : base(options)
        {
        }

        public DbSet<Album> Album { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ScheduledTrip> ScheduledTrip { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var userRoleId = "8e037e66-c280-4254-9129-48f7a0257804";
            var role = new IdentityRole
            {
                Name = "User",
                NormalizedName = "User", Id = userRoleId,
                ConcurrencyStamp = userRoleId,
            };
            builder.Entity<IdentityRole>().HasData(role);
        }
    }
}