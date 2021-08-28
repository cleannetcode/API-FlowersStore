using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API_FlowersStore.DataAccess.MSSQL.Entities;

namespace API_FlowersStore.DataAccess.MSSQL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Name)
                 .IsUnique();

            builder.Property(x => x.Name).HasMaxLength(30);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Role).HasMaxLength(40);

            builder.HasMany(x => x.Supplies)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(x => x.UserId)
                .IsRequired();
        }
    }
}