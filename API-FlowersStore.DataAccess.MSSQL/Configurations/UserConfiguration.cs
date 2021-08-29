using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API_FlowersStore.DataAccess.MSSQL.Entities;
using System;

namespace API_FlowersStore.DataAccess.MSSQL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Name)
                 .IsUnique();

            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
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

            builder.HasData
            (
                new User[]
                {
                    new User
                    {
                        Id = 1,
                        Name = "Admin",
                        Email = "Admin@gmail.com",
                        CreatedDate = DateTime.Now,
                        Password = "Admin",
                        Role = "Admin"
                    },

                    new User
                    {
                        Id = 2,
                        Name = "FlowersProvider",
                        Email = "FlowersProvider@gmail.com",
                        CreatedDate = DateTime.Now,
                        Password = "123",
                        Role = "Provider"
                    },

                    new User
                    {
                        Id = 3,
                        Name = "BouqsCustomer",
                        Email = "BouqsCustomer@gmail.com",
                        CreatedDate = DateTime.Now,
                        Password = "123",
                        Role = "Customer"
                    },

                    new User
                    {
                        Id = 4,
                        Name = "RomanCustomer",
                        Email = "RomanCustomer@gmail.com",
                        CreatedDate = DateTime.Now,
                        Password = "123",
                        Role = "Customer"
                    },

                    new User
                    {
                        Id = 5,
                        Name = "RomanProvider",
                        Email = "RomanProvider@gmail.com",
                        CreatedDate = DateTime.Now,
                        Password = "123",
                        Role = "Provider"
                    }
                }
            );
        }
    }
}