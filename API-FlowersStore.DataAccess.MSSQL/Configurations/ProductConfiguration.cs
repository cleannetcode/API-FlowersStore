using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API_FlowersStore.DataAccess.MSSQL.Entities;

namespace API_FlowersStore.DataAccess.MSSQL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(p => new { p.Name, p.UserId })
                   .IsUnique();

            builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.Color).HasMaxLength(40);
            builder.Property(x => x.Price).HasPrecision(38, 18);

            builder.HasMany(x => x.Supplies)
                .WithOne(x => x.Product)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(x => x.ProductId)
                .IsRequired();

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Product)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(x => x.ProductId)
                .IsRequired();

            builder.HasOne(x => x.User)
             .WithMany(x => x.Products)
             .OnDelete(DeleteBehavior.NoAction)
             .HasForeignKey(x => x.UserId)
             .IsRequired();
        }
    }
}