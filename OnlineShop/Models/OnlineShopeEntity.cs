using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace OnlineShop.Models
{
    public class OnlineShopeEntity: IdentityDbContext<User>
    {
        public OnlineShopeEntity(DbContextOptions options):base(options)
        {

        }

       
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(a => a.Cart)
            .WithOne(a => a.User)
            .HasForeignKey<Cart>(c => c.UserId);
            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
           // base.OnModelCreating(modelBuilder);
       // }

    }

}
