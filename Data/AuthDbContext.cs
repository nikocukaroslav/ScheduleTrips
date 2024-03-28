using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Save__plan_your_trips.Data
{
    public class AuthDbContext : IdentityDbContext
    {

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var userRoleId = "8e037e66-c280-4254-9129-48f7a0257804";

            var role = new IdentityRole
            {
                Name = "User",
                NormalizedName = "User",
                Id = userRoleId,
                ConcurrencyStamp = userRoleId,
            };

            builder.Entity<IdentityRole>().HasData(role);

        }
    }
}
