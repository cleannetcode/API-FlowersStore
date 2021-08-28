using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API_FlowersStore.DataAccess.MSSQL.Entities;

namespace API_FlowersStore.DataAccess.MSSQL.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type).HasMaxLength(40);
        }
    }
}