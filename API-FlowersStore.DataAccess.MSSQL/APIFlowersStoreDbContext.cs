using Microsoft.EntityFrameworkCore;
using API_FlowersStore.DataAccess.MSSQL.Configurations;
using API_FlowersStore.DataAccess.MSSQL.Entities;


namespace API_FlowersStore.DataAccess.MSSQL
{
    public class APIFlowersStoreDbContext : DbContext
    {
        public APIFlowersStoreDbContext(DbContextOptions<APIFlowersStoreDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Supply> Supplies { get; set; }

        public DbSet<Order> Orders { get; set; }

       // public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SupplyCardConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}