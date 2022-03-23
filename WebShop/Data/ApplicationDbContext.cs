using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebShop.Models.Enteties;

namespace WebShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<PlantCategory> Category { get; set; }
        public DbSet<PlantSize> PlantSizes { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProductOrder>().HasKey(po => new { po.ProductId, po.OrderId });
            //builder.Entity<Order>().HasQueryFilter(p => p.OrderDate > DateTime.Now); //Hämtar bara orders efter DateTime.Now

        }
    }
}