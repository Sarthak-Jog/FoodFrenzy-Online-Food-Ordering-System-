using FoodFrenzy.Models;
using Microsoft.EntityFrameworkCore;
namespace FoodFrenzy.Data
{
    public class FoodFrenzyDbContext : DbContext
    {
        public FoodFrenzyDbContext(DbContextOptions<FoodFrenzyDbContext> options)
        : base(options)
        {
        }
        // DbSets for each model
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and entity properties if needed
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithMany(p => p.Orders)
                .UsingEntity(j => j.ToTable("OrderProducts"));

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Carts)
                .UsingEntity(j => j.ToTable("CartProducts"));

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CustomerId);

            modelBuilder.Entity<Order>()
       .Property(o => o.BillAmount)
       .HasColumnType("decimal(18,2)");
        }
    }
        
}
