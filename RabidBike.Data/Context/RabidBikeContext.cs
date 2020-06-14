using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RabidBike.Domain.Entities;

namespace RabidBike.Data.Context
{
    public class RabidBikeContext : IdentityDbContext<ApplicationUser>
    {
        public RabidBikeContext(DbContextOptions<RabidBikeContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Condition> Conditions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Item>()
            //    .Property(p => p.ItemNumber)
                
        }
    }
}
